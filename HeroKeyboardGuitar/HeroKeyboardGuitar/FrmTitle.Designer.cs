namespace HeroKeyboardGuitar {
    partial class FrmTitle {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            btnStart = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnStart.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnStart.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStart.ForeColor = System.Drawing.Color.Black;
            btnStart.Location = new System.Drawing.Point(535, 503);
            btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(194, 120);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // FrmTitle
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.title;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1211, 753);
            Controls.Add(btnStart);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FrmTitle";
            Text = "Hero Keyboard Guitar";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += FrmTitle_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnStart;
    }
}