using Newtonsoft.Json.Linq;
using SocketIOClient;
using System;
using System.Windows.Forms;

namespace Avioane
{
    public class Main
    {
        public string GameCode;
        
        public string PlayerName;
        public string EnemyName;

        string BackendUrl = "http://localhost";
        string BackendPort = "3000";

        Boolean gameInProgress = false;
        Boolean enemyLeft = false;

        private SocketIO client;

        private InputName InputNameForm;
        private Game GameForm;
        private Actions ActionsFrame;
        private WaitingLobby WaitingLobbyForm;
        private JoinLobby JoinLobbyForm;
        private Lobby LobbyForm;

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
                        }

                        this.ActionsFrame.Show();
                    });

                    enemyLeft = true;
                    gameInProgress = false;
                    MessageBox.Show("Your enemy left the game", "Disconnect");
                }
            });

            client.ConnectAsync();
        }

        private async void SendServerMessage(string eventName, string data)
        {
            await client.EmitAsync(eventName, data);
        }

        // --- InputName.cs ---
        public void SubmitInputName(string PlayerName)
        {
            this.PlayerName = PlayerName;

            this.InputNameForm.Hide();
            this.ActionsFrame.Show();
        }
        // --- InputName.cs ---

        // --- Actions.cs ---
        public void SubmitCreateGame()
        {
            SendServerMessage("create-game", this.PlayerName);
        }

        public void SubmitShowJoinGame()
        {
            this.ActionsFrame.Hide();
            this.JoinLobbyForm.Show();
        }
        // --- Actions.cs ---

        // --- JoinLobby.cs --- 
        public void SubmitJoinGame(string gameCode)
        {
            this.GameCode = gameCode;
 
            JObject jsonObject = new JObject();
            jsonObject["playerName"] = this.PlayerName;
            jsonObject["gameCode"] = this.GameCode;

            SendServerMessage("join-lobby", jsonObject.ToString());
        }
        // --- JoinLobby.cs --- 
    }
}
