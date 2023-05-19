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
        }

        private void submit_Click(object sender, EventArgs e)
        {
            main.SubmitInputName(this.nameInput.Text);
        }
    }
}
