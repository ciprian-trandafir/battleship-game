using System.Windows.Forms;

namespace Avioane
{
    public partial class WaitingLobby : Form
    {
        Main main;

        public WaitingLobby(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void setLobbyId()
        {
            this.lobbyID.Text = this.main.GameCode;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
