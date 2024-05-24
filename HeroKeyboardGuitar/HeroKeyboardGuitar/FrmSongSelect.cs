using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace HeroKeyboardGuitar {
    internal partial class FrmSongSelect : Form {
        private readonly string SONGS_ROOT_PATH = $"{Application.StartupPath}../../../Songs/";

        public FrmSongSelect() {
            InitializeComponent();
<<<<<<< Updated upstream
=======
            // Load default text for the comboboxes that are initially hidden
            comboBox1.Text = "--Select a Song--";
            comboBox2.Text = "--Select a Song--";
            comboBox3.Text = "--Select a Song--";
            difficulty.Text = "Normal";
>>>>>>> Stashed changes
        }

        private void FrmSongSelect_Load(object sender, EventArgs e) {
            int top = 50;
            int left = 20;
            const int size = 300;
            const int spacing = 50;
            foreach (var songFilePath in Directory.GetFiles(SONGS_ROOT_PATH)) {
                var song = Path.GetFileNameWithoutExtension(songFilePath);
                var songName = song.Split('_')[0];
                GenreType genre;
                if (!Enum.TryParse(song.Split('_')[1], true, out genre)) {
                    genre = GenreType.COUNTRY;
                }
<<<<<<< Updated upstream
                Button btnSong = new() {
                    BackgroundImage = Game.GetBg(genre),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Width = size,
                    Height = size,
                    Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(songName.ToLower()),
                    TextAlign = ContentAlignment.BottomCenter,
                    Font = new Font("Arial", 30),
                    ForeColor = Color.Cyan,
                    Top = top,
                    Left = left,
                };
                left += size + spacing;
                var filePath = songFilePath;
                btnSong.Click += (e, sender) => {
                    Game.SetCurSong(filePath, genre);
                    FrmMain frmMain = new();
                    frmMain.Show();
                };
                Controls.Add(btnSong);
=======

                // Add Rock and RNB to Picture 1 
                if (genre == GenreType.ROCK || genre == GenreType.RNB)
                {
                    comboBox1.Items.Add(genre);

                }
                // Add POP to Picture 2 
                else if (genre == GenreType.POP)
                {
                    comboBox2.Items.Add(genre);
                }
                // Add anything else to Picture 3 
                else { comboBox3.Items.Add(genre); }

                // Add <filepath,genre> to the dictionary called "songs" as a key:value pair 
                songs.Add(filePath, genre);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Load highly saturated image
            pictureBox1.BackgroundImage = Properties.Resources.Picture2;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            // Make the combobox visible 
            comboBox1.Visible = true;

            // If other comboboxes are visible, make them invisible
            if (comboBox2.Visible || comboBox3.Visible)
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
            }
            // If other boxes are visible, make them invisible
            if (button3.Visible || button2.Visible)
            {
                button3.Visible = false;
                button2.Visible = false;
            }
            // Reset other comboboxes to default state
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Load highly saturated image
            pictureBox2.BackgroundImage = Properties.Resources.Picture3;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            // Make the combobox visible 
            comboBox2.Visible = true;

            // If other comboboxes are visible, make them invisible
            if (comboBox1.Visible || comboBox3.Visible)
            {
                comboBox1.Visible = false;
                comboBox3.Visible = false;
            }
            // If other boxes are visible, make them invisible
            if (button1.Visible || button3.Visible)
            {
                button1.Visible = false;
                button3.Visible = false;
            }
            // Reset other comboboxes to default state
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Load funny mario gif
            pictureBox3.BackgroundImage = Properties.Resources.ezgif_1_453554342f;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

            // Make the combobox visible
            comboBox3.Visible = true;

            // If other comboboxes are visible, make them invisible
            if (comboBox1.Visible || comboBox2.Visible)
            {
                comboBox1.Visible = false;
                comboBox2.Visible = false;
            }
            // If other boxes are visible, make them invisible
            if (button1.Visible || button2.Visible)
            {
                button1.Visible = false;
                button2.Visible = false;
            }
            // Reset other comboboxes to default state
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;


        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // Image Color 
            pictureBox1.BackgroundImage = Properties.Resources.rnb___Copy;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            // Image MonoChrome 
            pictureBox1.BackgroundImage = Properties.Resources.Picture1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            // Image Color 
            pictureBox2.BackgroundImage = Properties.Resources.pop___Copy;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            // Image MonoChrome
            pictureBox2.BackgroundImage = Properties.Resources.Picture4;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            // Image Color
            pictureBox3.BackgroundImage = Properties.Resources.mario;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            // Image MonoChrome
            //pictureBox3.Image = null;
            pictureBox3.BackgroundImage = Properties.Resources.Picture6;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            // Image Saturation
            pictureBox1.BackgroundImage = Properties.Resources.Picture2;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            // Image Saturation (just in case)
            pictureBox1.BackgroundImage = Properties.Resources.Picture2;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            // Image MonoChrome
            pictureBox1.BackgroundImage = Properties.Resources.Picture2;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            // Remove ComboBox
            comboBox1.Visible = false;

        }

        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            // Image Saturation
            pictureBox2.BackgroundImage = Properties.Resources.Picture3;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            // Image Saturation (Just in case)
            pictureBox2.BackgroundImage = Properties.Resources.Picture3;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox2_MouseLeave(object sender, EventArgs e)
        {
            // Image MonoChrome
            pictureBox2.BackgroundImage = Properties.Resources.Picture3;
            // Remove ComboBox
            comboBox2.Visible = false;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox3_MouseEnter(object sender, EventArgs e)
        {
            // Image Saturation
            pictureBox3.BackgroundImage = Properties.Resources.ezgif_1_453554342f;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox3_MouseHover(object sender, EventArgs e)
        {
            // Image Saturation
            pictureBox3.BackgroundImage = Properties.Resources.ezgif_1_453554342f;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox3_MouseLeave(object sender, EventArgs e)
        {
            // Image MonoChrome 
            pictureBox3.BackgroundImage = Properties.Resources.ezgif_1_453554342f;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            // Remove ComboBox
            comboBox3.Visible = false;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If ComboBox selection has happened...
            if (comboBox1.SelectedIndex != -1)
            {
                // If button1 is invisible, make it visible
                if (!button1.Visible)
                {
                    button1.Visible = true;
                    button1.Text = "START " + comboBox1.SelectedItem + "!!!";
                }

                // If other buttons are visible, make them invisible 
                if (button2.Visible || button3.Visible)
                {
                    button2.Visible = false;
                    button3.Visible = false;
                }
                if (button1.Visible)
                {
                    button1.Text = "START " + comboBox1.SelectedItem + "!!!";
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If ComboBox selection has happened...
            if (comboBox2.SelectedIndex != -1)
            {
                // If button2 is invisible, make it visble 
                if (!button2.Visible)
                {
                    button2.Visible = true;
                    button2.Text = "START " + comboBox2.SelectedItem + "!!!";

                }
                // If other buttons are visible, make them invisble 
                if (button1.Visible || button3.Visible)
                {
                    button1.Visible = false;
                    button3.Visible = false;
                }
                if (button2.Visible)
                {
                    button2.Text = "START " + comboBox2.SelectedItem + "!!!";
                }
            }

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If ComboBox selection has already happened...
            if (comboBox3.SelectedIndex != -1)
            {
                // If button3 is invisible, make it visbile
                if (!button3.Visible)
                {
                    button3.Visible = true;
                    button3.Text = "START " + comboBox3.SelectedItem + "!!!";

                }
                // If other buttons are visible, make them invisible
                if (button1.Visible || button2.Visible)
                {
                    button1.Visible = false;
                    button2.Visible = false;
                }
                if (button3.Visible)
                {
                    button3.Text = "START " + comboBox3.SelectedItem + "!!!";
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Launch FrmMain.cs for song selected in ComboBox1
            Game.SetCurSong(songs.FirstOrDefault(x => x.Value == (HeroKeyboardGuitar.GenreType)comboBox1.SelectedItem).Key, (HeroKeyboardGuitar.GenreType)comboBox1.SelectedItem);
            FrmMain frmMain = new();
            frmMain.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Launch FrmMain.cs from song selected in ComboBox2
            Game.SetCurSong(songs.FirstOrDefault(x => x.Value == (HeroKeyboardGuitar.GenreType)comboBox2.SelectedItem).Key, (HeroKeyboardGuitar.GenreType)comboBox2.SelectedItem);
            FrmMain frmMain = new();
            frmMain.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Launch FrmMain.cs from song selected in ComboBox3
            Game.SetCurSong(songs.FirstOrDefault(x => x.Value == (HeroKeyboardGuitar.GenreType)comboBox3.SelectedItem).Key, (HeroKeyboardGuitar.GenreType)comboBox3.SelectedItem);
            FrmMain frmMain = new();
            frmMain.Show();
        }

        private void difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update Game.speed based on selected difficulty
            switch (difficulty.SelectedIndex)
            {
                case 0: // Easy
                    Game.speed = 0.3f;
                    break;
                case 1: // Normal
                    Game.speed = 0.5f;
                    break;
                case 2: // Hard
                    Game.speed = 0.8f;
                    break;
                default:
                    break;
                       
>>>>>>> Stashed changes
            }
        }
    }
}
