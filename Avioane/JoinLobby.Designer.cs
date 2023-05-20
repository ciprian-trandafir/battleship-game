namespace Avioane
{
    partial class JoinLobby
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
            this.label1 = new System.Windows.Forms.Label();
            this.gameID = new System.Windows.Forms.TextBox();
            this.submitGameID = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Game ID:";
            // 
            // gameID
            // 
            this.gameID.Location = new System.Drawing.Point(97, 216);
            this.gameID.Name = "gameID";
            this.gameID.Size = new System.Drawing.Size(192, 22);
            this.gameID.TabIndex = 1;
            // 
            // submitGameID
            // 
            this.submitGameID.Location = new System.Drawing.Point(111, 374);
            this.submitGameID.Name = "submitGameID";
            this.submitGameID.Size = new System.Drawing.Size(165, 54);
            this.submitGameID.TabIndex = 2;
            this.submitGameID.Text = "Join";
            this.submitGameID.UseVisualStyleBackColor = true;
            this.submitGameID.Click += new System.EventHandler(this.submitGameID_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(101, 38);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // JoinLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 474);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.submitGameID);
            this.Controls.Add(this.gameID);
            this.Controls.Add(this.label1);
            this.Name = "JoinLobby";
            this.Text = "Aviaonele • Join Lobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gameID;
        private System.Windows.Forms.Button submitGameID;
        private System.Windows.Forms.Button buttonBack;
    }
}