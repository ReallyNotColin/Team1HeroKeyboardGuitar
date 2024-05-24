using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace HeroKeyboardGuitar;

internal partial class FrmTitle : Form
{
    private readonly string PICS_ROOT_PATH = $"{Application.StartupPath}../../../Resources/";
    SoundPlayer sound;
    public FrmTitle()
    {
        InitializeComponent();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        FrmSongSelect frmSongSelect = new();
        frmSongSelect.Show();
        sound.Stop();

    }

    private void FrmTitle_Load(object sender, EventArgs e)
    {
        btnStart.Left = Width / 2 - btnStart.Width / 2;
        btnStart.Top = (int)(Height * 0.65);

        foreach (var soundfilepath in Directory.GetFiles(PICS_ROOT_PATH))
        {
            var song = Path.GetFileNameWithoutExtension(soundfilepath);
            var soundName = song.Split('_')[0];
            var filePath = soundfilepath;

            if (soundName == "Burn")
            {
                sound = new SoundPlayer(filePath);
            }
        }
        sound.PlayLooping();
    }

    private void open_instructions_Click(object sender, EventArgs e)
    {
        FrmInstructions instructions = new FrmInstructions();
        instructions.Show();
    }
}
