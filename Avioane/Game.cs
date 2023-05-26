using System;
using System.Collections.Generic;
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
        List<string> myBombs = new List<string>();
        List<string> usedBombs = new List<string>();

        public Game(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.resources = new ComponentResourceManager(typeof(Game));

            foreach (Control control in this.enemyPlanes.Controls)
            {
                if (control is Button button)
                {
                    button.Click += attackEnemy;
                }
            }

            myBombs.Add("bomb1");
            myBombs.Add("bomb2");
            myBombs.Add("bomb3");

            this.bomb1.Click += attackBomb;
            this.bomb2.Click += attackBomb;
            this.bomb3.Click += attackBomb;
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
            int count = planes.Count;
            int startIndex = Math.Max(0, count - 1 - int.Parse(planes[count - 1]));

            for (int i = 0; i < count - 1; i++)
            {
                string plane = planes[i];
                Button button = this.Controls.Find("my_" + plane, true).FirstOrDefault() as Button;

                if (startIndex > 0 && i >= startIndex)
                {
                    button.BackColor = Color.Gray;
                }
                else
                {
                    button.BackColor = Color.Black;
                }
            }
        }

        public void loadHits(dynamic hits)
        {
            for (int i = 0; i < hits.Count; i++)
            {
                string hit = hits[i];
                string[] hitData = hit.Split('?');

                Button button = this.Controls.Find("enemy_" + hitData[0], true).FirstOrDefault() as Button;

                switch (hitData[1])
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

        public void loadBombs()
        {
            foreach (string bomb in myBombs)
            {
                if (!usedBombs.Contains(bomb))
                {
                    Console.WriteLine(bomb);
                    Button button = this.Controls.Find(bomb, true).FirstOrDefault() as Button;
                    button.Enabled = true;
                }
            }
        }

        private void attackBomb(object sender, EventArgs e)
        {
            Button target = sender as Button;

            usedBombs.Add(target.Name);
            this.bomb1.Enabled = false;
            this.bomb2.Enabled = false;
            this.bomb3.Enabled = false;

            this.main.SubmitAttackBomb(target.Name);
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

        public void attackResponse(string status, string target, int show_feedback)
        {
            if (show_feedback == 1)
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
            else
            {
                foreach (Control control in this.enemyPlanes.Controls)
                {
                    if (control is Button button)
                    {
                        button.BackgroundImage = null;
                    }
                }
            }
        }
    }
}
