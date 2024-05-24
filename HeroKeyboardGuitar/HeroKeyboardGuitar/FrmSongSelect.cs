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
            }
        }
    }
}
