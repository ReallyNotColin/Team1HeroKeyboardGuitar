using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroKeyboardGuitar
{
    public partial class FrmScoreInput : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public string PlayerID { get; private set; }
        public bool UploadScore { get; private set; }

        public FrmScoreInput()
        {
            InitializeComponent();
            UploadScore = false;
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (txtPlayerID.Text.Length == 3)
            {
                PlayerID = txtPlayerID.Text;
                UploadScore = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter exactly three characters.");
            }
        }

        private void btn_ignore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
