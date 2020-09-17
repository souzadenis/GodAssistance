using System.Windows.Forms;

namespace God
{
    partial class App
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
            this.barraAudio = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // barraAudio
            // 
            this.barraAudio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraAudio.Location = new System.Drawing.Point(0, 154);
            this.barraAudio.Name = "barraAudio";
            this.barraAudio.Size = new System.Drawing.Size(247, 41);
            this.barraAudio.TabIndex = 0;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(247, 195);
            this.Controls.Add(this.barraAudio);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            int pos_x = Screen.PrimaryScreen.Bounds.Width - (ClientSize.Width + 1);
            int pos_y = Screen.PrimaryScreen.Bounds.Height - (ClientSize.Height + 30);
            this.Location = new System.Drawing.Point(pos_x, pos_y);
            this.StartPosition = FormStartPosition.Manual;
            this.MaximizeBox = false;
            this.Name = "App";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.Text = "God";
            this.Load += new System.EventHandler(this.Start);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar barraAudio;
    }
}

