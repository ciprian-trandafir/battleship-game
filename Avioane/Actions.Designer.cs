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
            this.playerName = new System.Windows.Forms.Label();
            this.gameLevel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // createGame
            // 
            this.createGame.Location = new System.Drawing.Point(12, 159);
            this.createGame.Name = "createGame";
            this.createGame.Size = new System.Drawing.Size(417, 82);
            this.createGame.TabIndex = 0;
            this.createGame.Text = "Create Game";
            this.createGame.UseVisualStyleBackColor = true;
            this.createGame.Click += new System.EventHandler(this.createGame_Click);
            // 
            // joinGame
            // 
            this.joinGame.Location = new System.Drawing.Point(12, 265);
            this.joinGame.Name = "joinGame";
            this.joinGame.Size = new System.Drawing.Size(417, 69);
            this.joinGame.TabIndex = 1;
            this.joinGame.Text = "Join Game";
            this.joinGame.UseVisualStyleBackColor = true;
            this.joinGame.Click += new System.EventHandler(this.joinGame_Click);
            // 
            // playerName
            // 
            this.playerName.AutoSize = true;
            this.playerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerName.Location = new System.Drawing.Point(89, 30);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(103, 38);
            this.playerName.TabIndex = 2;
            this.playerName.Text = "label1";
            // 
            // gameLevel
            // 
            this.gameLevel.FormattingEnabled = true;
            this.gameLevel.Location = new System.Drawing.Point(57, 114);
            this.gameLevel.Name = "gameLevel";
            this.gameLevel.Size = new System.Drawing.Size(328, 24);
            this.gameLevel.TabIndex = 3;
            // 
            // Actions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 347);
            this.Controls.Add(this.gameLevel);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.joinGame);
            this.Controls.Add(this.createGame);
            this.Name = "Actions";
            this.Text = "Battleship • Choose action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button createGame;
        private System.Windows.Forms.Button joinGame;
        public System.Windows.Forms.Label playerName;
        private System.Windows.Forms.ComboBox gameLevel;
    }
    #endregion
}