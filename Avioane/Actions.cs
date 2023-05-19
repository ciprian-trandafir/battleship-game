﻿using System;
using System.Windows.Forms;

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
        }

        private void createGame_Click(object sender, EventArgs e)
        {
            main.SubmitCreateGame();
        }
    }
}