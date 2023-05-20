using System;
using System.Windows.Forms;

namespace Avioane
{
    public partial class InputName : Form
    {
        Main main;

        public InputName(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string playerName = this.nameInput.Text;
            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please input a valid name! 😠", "Error");
                return;
            }

            this.main.PlayerName = playerName;
            this.main.ActionsFrame.playerName.Text = "Hi, " + playerName;

            this.main.InputNameForm.Hide();
            this.main.ActionsFrame.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
