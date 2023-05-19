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
    public partial class Lobby : Form
    {
        Main main;

        public Lobby(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public void setLobbyId()
        {
            this.lobbyID.Text = this.main.GameCode;
        }
        
        public void enemyJoined()
        {
            this.enemyName.Text = this.main.EnemyName;
        }
    }
}
