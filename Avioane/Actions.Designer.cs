namespace Avioane
{
    partial class Actions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createGame = new System.Windows.Forms.Button();
            this.joinGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createGame
            // 
            this.createGame.Location = new System.Drawing.Point(92, 87);
            this.createGame.Name = "createGame";
            this.createGame.Size = new System.Drawing.Size(188, 84);
            this.createGame.TabIndex = 0;
            this.createGame.Text = "Create Game";
            this.createGame.UseVisualStyleBackColor = true;
            this.createGame.Click += new System.EventHandler(this.createGame_Click);
            // 
            // joinGame
            // 
            this.joinGame.Location = new System.Drawing.Point(92, 237);
            this.joinGame.Name = "joinGame";
            this.joinGame.Size = new System.Drawing.Size(188, 84);
            this.joinGame.TabIndex = 1;
            this.joinGame.Text = "Join Game";
            this.joinGame.UseVisualStyleBackColor = true;
            // 
            // Actions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 402);
            this.Controls.Add(this.joinGame);
            this.Controls.Add(this.createGame);
            this.Name = "Actions";
            this.Text = "Actions";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button createGame;
        private System.Windows.Forms.Button joinGame;
    }
    #endregion
}