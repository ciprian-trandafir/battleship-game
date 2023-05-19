namespace Avioane
{
    partial class WaitingLobby
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lobbyTitle
            // 
            this.lobbyTitle.AutoSize = true;
            this.lobbyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lobbyTitle.Location = new System.Drawing.Point(200, 100);
            this.lobbyTitle.Name = "lobbyTitle";
            this.lobbyTitle.Size = new System.Drawing.Size(156, 38);
            this.lobbyTitle.TabIndex = 0;
            this.lobbyTitle.Text = "Lobby ID:";
            // 
            // lobbyID
            // 
            this.lobbyID.AutoSize = true;
            this.lobbyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lobbyID.Location = new System.Drawing.Point(215, 181);
            this.lobbyID.Name = "lobbyID";
            this.lobbyID.Size = new System.Drawing.Size(127, 38);
            this.lobbyID.TabIndex = 1;
            this.lobbyID.Text = "lobbyID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Waiting another player to join ..";
            // 
            // WaitingLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lobbyID);
            this.Controls.Add(this.lobbyTitle);
            this.Name = "WaitingLobby";
            this.Text = "Avioanele • Waiting to enter Lobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lobbyTitle;
        private System.Windows.Forms.Label lobbyID;
        private System.Windows.Forms.Label label1;
    }
}