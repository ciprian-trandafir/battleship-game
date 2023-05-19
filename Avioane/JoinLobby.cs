using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void JoinLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.ServerDisconnect();
        }
    }
}
