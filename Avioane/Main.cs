using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Avioane
{
    public class Main : Form
    {
        string GameCode;
        string PlayerName;
        string BackendUrl = "http://localhost";
        string BackendPort = "3000";

        private InputName InputNameForm;
        private Game GameForm;
        private Actions ActionsFrame;

        private StreamWriter writer;

        public Main() 
        {
            // initialize all forms
            InputNameForm = new InputName(this);
            GameForm = new Game();
            ActionsFrame = new Actions(this);

            // show inputNameForm
            InputNameForm.Show();


            TcpClient client = new TcpClient("localhost", 3000);
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            Thread receiveThread = new Thread(() =>
            {
                while (true)
                {
                    string response = reader.ReadLine();
                    //ProcessServerResponse(response);
                }
            });
            receiveThread.Start();
        }
        private void SendEventToServer(StreamWriter writer, string eventName, string eventData)
        {
            string payload = $"{eventName}:{eventData}";
            Console.WriteLine(payload);
            writer.WriteLine(payload);
        }

        private void ProcessServerResponse(string response)
        {
            Console.WriteLine(response);
        }

        public void SubmitInputName(string PlayerName)
        {
            this.PlayerName = PlayerName;

            SendEventToServer(this.writer, "join-lobby", "aaa");

            InputNameForm.Hide();
            ActionsFrame.Show();

            Console.WriteLine(this.PlayerName);
        }

        public void SubmitCreateGame()
        {
            this.CreateGame();
        }

        private async void CreateGame()
        {
            var dict = new Dictionary<string, string>
                {
                    {"playerName", this.PlayerName},
                };

            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(dict), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BackendUrl + BackendPort + "/games", content);

            if (response.IsSuccessStatusCode)
            {
                dynamic responseObject = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                this.GameCode = responseObject.data.game.code;
            } 
            else
            {
                MessageBox.Show("Something went wrong!", "Error");
            }
        }
    }
}
