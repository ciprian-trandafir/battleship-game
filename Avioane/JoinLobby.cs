using System;
using System.Windows.Forms;

namespace Avioane
{
    public partial class JoinLobby : Form
    {
        Main main;

        public JoinLobby(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void submitGameID_Click(object sender, EventArgs e)
        {
            main.SubmitJoinGame(this.gameID.Text);
            this.gameID.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.main.JoinLobbyForm.Hide();
            this.main.ActionsFrame.Show();
        }
    }
}
