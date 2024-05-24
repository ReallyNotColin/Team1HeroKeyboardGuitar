namespace HeroKeyboardGuitar {
    partial class FrmMain {
        private System.Windows.Forms.Button start_btn;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            tmrPlay = new System.Windows.Forms.Timer(components);
            picTarget = new System.Windows.Forms.PictureBox();
            lblScore = new System.Windows.Forms.Label();
            tmrScoreShrink = new System.Windows.Forms.Timer(components);
            panBg = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)picTarget).BeginInit();
            panBg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tmrPlay
            // 
            tmrPlay.Interval = 50;
            tmrPlay.Tick += tmrPlay_Tick;
            // 
            // picTarget
            // 
            picTarget.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            picTarget.BackColor = System.Drawing.Color.Transparent;
            picTarget.BackgroundImage = Properties.Resources._default;
            picTarget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            picTarget.Location = new System.Drawing.Point(372, 498);
            picTarget.Name = "picTarget";
            picTarget.Size = new System.Drawing.Size(120, 120);
            picTarget.TabIndex = 3;
            picTarget.TabStop = false;
            // 
            // lblScore
            // 
            lblScore.BackColor = System.Drawing.Color.Transparent;
            lblScore.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            lblScore.ForeColor = System.Drawing.Color.White;
            lblScore.Location = new System.Drawing.Point(0, 391);
            lblScore.Name = "lblScore";
            lblScore.Size = new System.Drawing.Size(1237, 89);
            lblScore.TabIndex = 5;
            lblScore.Text = "0";
            lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrScoreShrink
            // 
            tmrScoreShrink.Enabled = true;
            tmrScoreShrink.Tick += tmrScoreShrink_Tick;
            // 
            // panBg
            // 
            panBg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panBg.Controls.Add(label2);
            panBg.Controls.Add(label1);
            panBg.Controls.Add(button1);
            panBg.Controls.Add(lblScore);
            panBg.Dock = System.Windows.Forms.DockStyle.Top;
            panBg.Location = new System.Drawing.Point(0, 0);
            panBg.Name = "panBg";
            panBg.Size = new System.Drawing.Size(1237, 480);
            panBg.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.White;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(12, 145);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(807, 144);
            label2.TabIndex = 9;
            label2.Text = resources.GetString("label2.Text");
            label2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(22, 58);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(586, 73);
            label1.TabIndex = 7;
            label1.Text = "Press 'F' To Begin!!";
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(406, 178);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(176, 60);
            button1.TabIndex = 6;
            button1.Text = "Return to Menu";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pictureBox1.BackgroundImage = Properties.Resources.Cherry;
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox1.Location = new System.Drawing.Point(12, 451);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(194, 181);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1237, 644);
            Controls.Add(pictureBox1);
            Controls.Add(picTarget);
            Controls.Add(panBg);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "FrmMain";
            Text = "Play Song";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            KeyDown += FrmMain_KeyDown;
            KeyUp += FrmMain_KeyUp;
            ((System.ComponentModel.ISupportInitialize)picTarget).EndInit();
            panBg.ResumeLayout(false);
            panBg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer tmrPlay;
        private System.Windows.Forms.PictureBox picTarget;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer tmrScoreShrink;
        private System.Windows.Forms.Panel panBg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}
