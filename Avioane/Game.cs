﻿using System;
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
    public partial class Game : Form
    {
        Main main;

        public Game(Main main)
        {
            this.main = main;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
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
    }
}
