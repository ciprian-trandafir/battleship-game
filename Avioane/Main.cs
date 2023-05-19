
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avioane
{
    public class Main : Form
    {
        public string GameCode;
        
        public string PlayerName;
        public string EnemyName;

        string BackendUrl = "http://localhost";
        string BackendPort = "3000";

        private SocketIO client;

        private InputName InputNameForm;
        private Game GameForm;
        private Actions ActionsFrame;
        private Lobby LobbyForm;
        private JoinLobby JoinLobbyForm;

        public Main() 
        {
            // initialize all forms
            InputNameForm = new InputName(this);
            GameForm = new Game();
            ActionsFrame = new Actions(this);
            LobbyForm = new Lobby(this);
            JoinLobbyForm = new JoinLobby(this);

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
                    this.LobbyForm.setLobbyId();
                    this.LobbyForm.Show();
                });
            });

            client.On("joined-lobby", response =>
            {
                this.EnemyName = response.GetValue<string>();
                this.LobbyForm.enemyJoined();
            });

            client.ConnectAsync();
        }

        private async void SendServerMessage(string eventName, string data)
        {
            await client.EmitAsync(eventName, data);
        }

        public async void ServerDisconnect()
        {
            await client.DisconnectAsync();
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
