using System.Windows.Forms;

namespace Avioane
{
    public partial class Lobby : Form
    {
        Main main;

        public Lobby(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void SetNames(string playerName, string enemyName)
        {
            this.playerName.Text = playerName;
            this.enemyName.Text = enemyName;
        }

        public void SetTimer(string time)
        {
            this.gameCounter.Text = time;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
