namespace HeroKeyboardGuitar
{
    partial class FrmScoreInput
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
            btn_upload = new System.Windows.Forms.Button();
            btn_ignore = new System.Windows.Forms.Button();
            txtPlayerID = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btn_upload
            // 
            btn_upload.Location = new System.Drawing.Point(153, 451);
            btn_upload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new System.Drawing.Size(158, 100);
            btn_upload.TabIndex = 0;
            btn_upload.Text = "UPLOAD";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += btn_upload_Click;
            // 
            // btn_ignore
            // 
            btn_ignore.Location = new System.Drawing.Point(595, 451);
            btn_ignore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_ignore.Name = "btn_ignore";
            btn_ignore.Size = new System.Drawing.Size(158, 100);
            btn_ignore.TabIndex = 1;
            btn_ignore.Text = "IGNORE";
            btn_ignore.UseVisualStyleBackColor = true;
            btn_ignore.Click += btn_ignore_Click;
            // 
            // txtPlayerID
            // 
            txtPlayerID.Location = new System.Drawing.Point(309, 237);
            txtPlayerID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtPlayerID.MaxLength = 3;
            txtPlayerID.Name = "txtPlayerID";
            txtPlayerID.Size = new System.Drawing.Size(295, 27);
            txtPlayerID.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(117, 129);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(697, 76);
            label1.TabIndex = 3;
            label1.Text = "Insert a three letter name to upload your score and \r\ncompare how well you did compared to others!!!";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // FrmScoreInput
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(914, 600);
            Controls.Add(label1);
            Controls.Add(txtPlayerID);
            Controls.Add(btn_ignore);
            Controls.Add(btn_upload);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FrmScoreInput";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Button btn_ignore;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.Label label1;
    }
}