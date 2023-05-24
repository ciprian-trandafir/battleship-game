using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Avioane
{
    public partial class Actions : Form
    {
        Main main;

        public Actions(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            gameLevel.Items.Add("Easy");
            gameLevel.Items.Add("Medium");
            gameLevel.Items.Add("Hard");
            gameLevel.SelectedIndex = 2;
        }

        private void createGame_Click(object sender, EventArgs e)
        {
            main.SubmitCreateGame(this.gameLevel.GetItemText(this.gameLevel.SelectedItem));
        }

        private void joinGame_Click(object sender, EventArgs e)
        {
            this.main.ActionsFrame.Hide();
            this.main.JoinLobbyForm.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
