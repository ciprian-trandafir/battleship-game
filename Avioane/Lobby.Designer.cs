namespace Avioane
{
    partial class Lobby
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
            this.lobbyTitle = new System.Windows.Forms.Label();
            this.lobbyID = new System.Windows.Forms.Label();
            this.enemyName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lobbyTitle
            // 
            this.lobbyTitle.AutoSize = true;
            this.lobbyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lobbyTitle.Location = new System.Drawing.Point(146, 101);
            this.lobbyTitle.Name = "lobbyTitle";
            this.lobbyTitle.Size = new System.Drawing.Size(156, 38);
            this.lobbyTitle.TabIndex = 0;
            this.lobbyTitle.Text = "Lobby ID:";
            // 
            // lobbyID
            // 
            this.lobbyID.AutoSize = true;
            this.lobbyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lobbyID.Location = new System.Drawing.Point(157, 181);
            this.lobbyID.Name = "lobbyID";
            this.lobbyID.Size = new System.Drawing.Size(127, 38);
            this.lobbyID.TabIndex = 1;
            this.lobbyID.Text = "lobbyID";
            // 
            // enemyName
            // 
            this.enemyName.AutoSize = true;
            this.enemyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyName.Location = new System.Drawing.Point(28, 419);
            this.enemyName.Name = "enemyName";
            this.enemyName.Size = new System.Drawing.Size(374, 29);
            this.enemyName.TabIndex = 2;
            this.enemyName.Text = "Waiting another player to join ..";
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 497);
            this.Controls.Add(this.enemyName);
            this.Controls.Add(this.lobbyID);
            this.Controls.Add(this.lobbyTitle);
            this.Name = "Lobby";
            this.Text = "Avioanele • Lobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lobbyTitle;
        private System.Windows.Forms.Label lobbyID;
        private System.Windows.Forms.Label enemyName;
    }
}