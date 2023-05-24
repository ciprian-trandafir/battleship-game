using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Avioane
{
    public class Main
    {
        public string GameCode;
        
        public string PlayerName;
        public string EnemyName;
        public int PlayerCode;

        string BackendUrl = "http://localhost";
        string BackendPort = "3000";

        dynamic planes;
        Boolean gameInProgress = false;
        Boolean enemyLeft = false;

        private SocketIO client;

        public InputName InputNameForm;
        public Game GameForm;
        public Actions ActionsFrame;
        public WaitingLobby WaitingLobbyForm;
        public JoinLobby JoinLobbyForm;
        public Lobby LobbyForm;

        public Main() 
        {
            // initialize all forms
            InputNameForm = new InputName(this);
            GameForm = new Game(this);
            ActionsFrame = new Actions(this);
            WaitingLobbyForm = new WaitingLobby(this);
            JoinLobbyForm = new JoinLobby(this);
            LobbyForm = new Lobby(this);    

            InputNameForm.Show();

            client = new SocketIO(BackendUrl + ":" + BackendPort);

            client.OnConnected += async (sender, e) =>
            {
                Console.WriteLine("Successfully connected to websocket!");
            };

            client.On("client-error", response =>
            {
                MessageBox.Show(response.GetValue<string>(), "Error");
            });

            client.On("game-created", response =>
            {
                this.GameCode = response.GetValue<string>();
                this.PlayerCode = 1;

                ActionsFrame.Invoke((MethodInvoker)delegate
                {
                    this.ActionsFrame.Hide();
                    this.WaitingLobbyForm.setLobbyId();
                    this.WaitingLobbyForm.Show();
                });
            });

            client.On("joined-lobby", response =>
            {
                gameInProgress = true;
                enemyLeft = false;
                this.EnemyName = response.GetValue<string>();
                WaitingLobbyForm.Invoke((MethodInvoker)delegate
                {
                    this.WaitingLobbyForm.Hide();
                    this.LobbyForm.Show();
                    this.LobbyForm.SetNames(this.PlayerName, this.EnemyName);
                });
            });

            client.On("success-join-lobby", response =>
            {
                gameInProgress = true;
                enemyLeft = false;
                
                this.EnemyName = response.GetValue<string>();
                this.PlayerCode = 2;

                JoinLobbyForm.Invoke((MethodInvoker)delegate
                {
                    this.JoinLobbyForm.Hide();
                    this.LobbyForm.Show();
                    this.LobbyForm.SetNames(this.PlayerName, this.EnemyName);
                });
            });

            client.On("update-counter", response =>
            {
                if (enemyLeft)
                {
                    return;
                }

                LobbyForm.Invoke((MethodInvoker)delegate
                {
                    this.LobbyForm.SetTimer(response.GetValue<string>());
                });
            });

            client.On("start-game", response =>
            {
                if (enemyLeft)
                {
                    return;
                }

                LobbyForm.Invoke((MethodInvoker)delegate
                {
                    this.LobbyForm.Hide();
                    this.GameForm.setNames();
                    this.GameForm.Show();

                    planes = JsonConvert.DeserializeObject<List<string>>(response.GetValue<string>());

                    this.GameForm.loadPlanes(planes);

                    if (this.PlayerCode == 1)
                    {
                        this.GameForm.gameState.Text = "Attack ..";
                        this.GameForm.gameState.ForeColor = Color.Green;
                        this.GameForm.enemyPlanes.Enabled = true;
                    } 
                    else
                    {
                        this.GameForm.gameState.Text = "Waiting ..";
                        this.GameForm.gameState.ForeColor = Color.Red;
                        this.GameForm.enemyPlanes.Enabled = false;
                    }
                });
            });

            client.On("cancel-game", response => 
            {
                if (gameInProgress)
                {
                    LobbyForm.Invoke((MethodInvoker)delegate
                    {
                        if (this.LobbyForm.Visible)
                        {
                            this.LobbyForm.Hide();
                        }

                        if (this.GameForm.Visible)
                        {
                            this.GameForm.Hide();
                            this.GameForm = new Game(this);
                        }

                        this.ActionsFrame.Show();
                    });

                    enemyLeft = true;
                    gameInProgress = false;
                    MessageBox.Show("Your enemy left the game", "Disconnect");
                }
            });

            client.On("attacked", response =>
            {
                List<string> resp = JsonConvert.DeserializeObject<List<string>>(response.GetValue<string>());
                GameForm.Invoke((MethodInvoker)delegate
                {
                    this.GameForm.attacked(resp[0], resp[1]);
                });
            });

            client.On("attack-response", response =>
            {
                List<string> resp = JsonConvert.DeserializeObject<List<string>>(response.GetValue<string>());
                GameForm.Invoke((MethodInvoker)delegate
                {
                    this.GameForm.attackResponse(resp[0], resp[1]);
                });
            });

            client.On("winner", response =>
            {
                GameForm.Invoke((MethodInvoker)delegate
                {
                    if (this.GameForm.Visible)
                    {
                        this.GameForm.Hide();
                        this.GameForm = new Game(this);
                    }

                    this.ActionsFrame.Show();
                });

                enemyLeft = false;
                gameInProgress = false;
                MessageBox.Show("You win", "War result");
            });

            client.On("defeated", response =>
            {
                GameForm.Invoke((MethodInvoker)delegate
                {
                    if (this.GameForm.Visible)
                    {
                        this.GameForm.Hide();
                        this.GameForm = new Game(this);
                    }

                    this.ActionsFrame.Show();
                });

                enemyLeft = false;
                gameInProgress = false;
                MessageBox.Show("You are defeated!", "War result");
            });

            client.ConnectAsync();
        }

        private async void SendServerMessage(string eventName, string data)
        {
            await client.EmitAsync(eventName, data);
        }

        public void SubmitCreateGame(string level)
        { 
            JObject jsonObject = new JObject();
            jsonObject["playerName"] = this.PlayerName;
            jsonObject["level"] = level;

            SendServerMessage("create-game", jsonObject.ToString());
        }

        public void SubmitJoinGame(string gameCode)
        {
            this.GameCode = gameCode;
 
            JObject jsonObject = new JObject();
            jsonObject["playerName"] = this.PlayerName;
            jsonObject["gameCode"] = this.GameCode;

            SendServerMessage("join-lobby", jsonObject.ToString());
        }

        public void SubmitAttackEnemy(string target)
        {
            JObject jsonObject = new JObject();
            jsonObject["playerCode"] = this.PlayerCode;
            jsonObject["gameCode"] = this.GameCode;
            jsonObject["target"] = target;

            SendServerMessage("attack", jsonObject.ToString());
        }

        public void SubmitAttackBomb(string target)
        {
            JObject jsonObject = new JObject();
            jsonObject["playerCode"] = this.PlayerCode;
            jsonObject["gameCode"] = this.GameCode;
            jsonObject["bombName"] = target;

            SendServerMessage("attackBomb", jsonObject.ToString());
        }
    }
}
