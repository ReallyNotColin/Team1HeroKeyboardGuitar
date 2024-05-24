namespace HeroKeyboardGuitar {
    partial class FrmSongSelect {
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
<<<<<<< Updated upstream
        private void InitializeComponent() {
            SuspendLayout();
            // 
=======
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSongSelect));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            comboBox2 = new System.Windows.Forms.ComboBox();
            comboBox3 = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            difficulty = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            pictureBox1.BackColor = System.Drawing.Color.White;
            pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox1.Location = new System.Drawing.Point(12, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(329, 438);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            pictureBox2.BackColor = System.Drawing.Color.Black;
            pictureBox2.BackgroundImage = Properties.Resources.Picture4;
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox2.Location = new System.Drawing.Point(364, 39);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(329, 438);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox2.MouseEnter += pictureBox2_MouseEnter;
            pictureBox2.MouseLeave += pictureBox2_MouseLeave;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            pictureBox3.BackColor = System.Drawing.Color.White;
            pictureBox3.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox3.Location = new System.Drawing.Point(719, 39);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(329, 438);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            pictureBox3.MouseEnter += pictureBox3_MouseEnter;
            pictureBox3.MouseLeave += pictureBox3_MouseLeave;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            comboBox1.BackColor = System.Drawing.SystemColors.Window;
            comboBox1.FormattingEnabled = true;
            comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            comboBox1.Location = new System.Drawing.Point(110, 296);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 23);
            comboBox1.TabIndex = 4;
            comboBox1.Visible = false;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.MouseEnter += comboBox1_MouseEnter;
            comboBox1.MouseLeave += comboBox1_MouseLeave;
            comboBox1.MouseHover += comboBox1_MouseHover;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(471, 296);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(121, 23);
            comboBox2.TabIndex = 5;
            comboBox2.Visible = false;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox2.MouseEnter += comboBox2_MouseEnter;
            comboBox2.MouseLeave += comboBox2_MouseLeave;
            comboBox2.MouseHover += comboBox2_MouseHover;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(836, 296);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(121, 23);
            comboBox3.TabIndex = 6;
            comboBox3.Visible = false;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            comboBox3.MouseEnter += comboBox3_MouseEnter;
            comboBox3.MouseLeave += comboBox3_MouseLeave;
            comboBox3.MouseHover += comboBox3_MouseHover;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            button1.BackColor = System.Drawing.Color.MediumBlue;
            button1.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            button1.Location = new System.Drawing.Point(110, 492);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(181, 61);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            button2.BackColor = System.Drawing.Color.Blue;
            button2.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(424, 495);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(181, 58);
            button2.TabIndex = 8;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            button3.BackColor = System.Drawing.Color.Blue;
            button3.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button3.ForeColor = System.Drawing.Color.White;
            button3.Location = new System.Drawing.Point(789, 493);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(181, 60);
            button3.TabIndex = 9;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // difficulty
            // 
            difficulty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            difficulty.FormattingEnabled = true;
            difficulty.Items.AddRange(new object[] { "Easy", "Normal", "Hard" });
            difficulty.Location = new System.Drawing.Point(424, 10);
            difficulty.Name = "difficulty";
            difficulty.Size = new System.Drawing.Size(205, 23);
            difficulty.TabIndex = 10;
            difficulty.SelectedIndexChanged += difficulty_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(278, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(140, 23);
            label1.TabIndex = 11;
            label1.Text = "Difficulty: ";
            // 
>>>>>>> Stashed changes
            // FrmSongSelect
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(1060, 565);
<<<<<<< Updated upstream
=======
            Controls.Add(label1);
            Controls.Add(difficulty);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
>>>>>>> Stashed changes
            Name = "FrmSongSelect";
            Text = "Select Song";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += FrmSongSelect_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
<<<<<<< Updated upstream
=======

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox difficulty;
        private System.Windows.Forms.Label label1;
>>>>>>> Stashed changes
    }
}