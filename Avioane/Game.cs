using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Avioane
{
    public partial class Game : Form
    {
        Main main;
        ComponentResourceManager resources;

        public Game(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.resources = new ComponentResourceManager(typeof(Game));

            foreach (Control control in this.enemyPlanes.Controls)
            {
                if (control is Button button)
                {
                    button.Click += attackEnemy;
                }
            }
        }

        public void setNames()
        {
            this.myPlanes.Text = this.main.PlayerName;
            this.enemyPlanes.Text = this.main.EnemyName;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void loadPlanes(dynamic planes)
        {
            foreach (string plane in planes)
            {
                Button button = this.Controls.Find("my_" + plane, true).FirstOrDefault() as Button;
                button.BackColor = Color.Black;
            }
        }

        private void attackEnemy(object sender, EventArgs e)
        {
            Button target = sender as Button;

            if (target != null)
            {
                this.main.SubmitAttackEnemy(target.Name);
                
                target.Enabled = false;
                this.gameState.Text = "Waiting ..";
                this.gameState.ForeColor = Color.Red;
                this.enemyPlanes.Enabled = false;
            }
        }

        public void attacked(string status, string target)
        {
            Button button = this.Controls.Find("my_" + target, true).FirstOrDefault() as Button;

            switch (status)
            {
                case "air":
                    button.BackgroundImage = ((Image)(resources.GetObject("missed")));
                    break;
                case "hit":
                    button.FlatAppearance.BorderColor = Color.Red;
                    button.FlatAppearance.BorderSize = 5;
                    break;
            }

            this.gameState.Text = "Attack ..";
            this.gameState.ForeColor = Color.Green;
            this.enemyPlanes.Enabled = true;
        }

        public void attackResponse(string status, string target)
        {
            Button button = this.Controls.Find("enemy_" + target, true).FirstOrDefault() as Button;
            switch (status)
            {
                case "air":
                    button.BackgroundImage = ((Image)(resources.GetObject("missed")));
                    break;
                case "hit":
                    button.BackgroundImage = ((Image)(resources.GetObject("hit")));
                    break;
            }
        }
    }
}
