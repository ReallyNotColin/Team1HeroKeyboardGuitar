using AudioAnalyzing;
using HeroKeyboardGuitar.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Channels;
using System.Windows.Forms;

namespace HeroKeyboardGuitar;

internal partial class FrmMain : Form
{
    private bool game_start = false;
    private bool game_stop = false;
    private bool gameStarted = false;
    private Timer game_timer;
    private DateTime game_start_time;
    private float noteSpeed = Game.speed;
    private List<Note> notes;
    private Audio curSong;
    private Score score;
    public bool isSpacebarHeld = false;
    private bool isTap = false;
    private DateTime spacePressTime;
    private int total_notes_hit;
    public bool isPaused = false;
    private TimeSpan pausedTime;
    private bool wasPlaying = false;
    FrmInstructions instructions = new FrmInstructions();
    private bool called_upload = false;


    // for double buffering
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
            return cp;
        }
    }

    public FrmMain()
    {
        InitializeComponent();
    }

    public void FrmMain_Load(object sender, EventArgs e)
    {
        score = new();
        lblScore.Text = score.Amount.ToString();
        panBg.BackgroundImage = Game.GetInstance().GetBg();
        panBg.Height = (int)(Height * 0.8);
        curSong = Game.GetInstance().CurSong;
        notes = new();
        foreach (var actionTime in curSong.ActionTimes)
        {
            double x = actionTime * noteSpeed + picTarget.Left + picTarget.Width;
            const int noteSize = 50;
            if (notes.Any(note => (x - note.Pic.Left) < noteSize / 2))
            {
                continue;
            }
            // Create note 
            PictureBox picNote = new()
            {
                BackColor = Color.Black,
                ForeColor = Color.Black,
                Width = noteSize,
                Height = noteSize,
                Top = picTarget.Top + picTarget.Height / 2 - noteSize / 2,
                Left = (int)x,
                BackgroundImage = Resources.marker,
                BackgroundImageLayout = ImageLayout.Stretch,
                Anchor = AnchorStyles.Bottom,
            };
            // Add the control
            Controls.Add(picNote);
            // Add note to the list 
            notes.Add(new(picNote, x));
        }
    }

    private void tmrPlay_Tick(object sender, EventArgs e)
    {
        int index = curSong.GetPosition();
        foreach (var note in notes)
        {

            if (!isPaused)
            {
                // Move the Notes?
                note.Move(tmrPlay.Interval * (noteSpeed * 1.3));
                if (note.CheckMiss(picTarget))
                {
                    score.Deduct(1);
                }
            }
            else
            {
                note.Pause();
            }

        }
        if (index >= curSong.GetNumberOfSamples() - 1)
        {
            tmrPlay.Enabled = false;
            foreach (var note in notes)
            {
                Controls.Remove(note.Pic);
                note.Dispose();
            }
        }
    }


    /// <summary>
    ///  USER INPUT KEY CONTROLS 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FrmMain_KeyDown(object sender, KeyEventArgs e)
    {
        // Hit the notes
        if (e.KeyCode == Keys.Space)
        {
            spacePressTime = DateTime.Now;
            isSpacebarHeld = false;
            picTarget.BackgroundImage = Resources.pressed;
        }
        // Start the game 
        if (e.KeyCode == Keys.F && !gameStarted)
        {
            // Set the flag to indicate that the game has started
            gameStarted = true;
            if (!game_start)
            {
                // Start the game
                label1.Dispose();
                Game.GetInstance().CurSong.Play();
                tmrPlay.Enabled = true;
                game_start_time = DateTime.Now;
                //game_timer.Interval= ((int)curSong.AudioLengthInMs);

                // Prepare to call GameTimer_Tick (Ends the game) 
                game_timer = new Timer();
                game_timer.Interval = 1000;
                game_timer.Tick += GameTimer_Tick;
                game_timer.Start();
            }
            else
            {
                // COLIN: Issue, if 'F' is pressed after the game starts, the game will break. 
                // COLIN: This suppression function doesn't work. For some reason, the AudioAnalyzing Play() function just freaks out despite countermeasures
                e.SuppressKeyPress = true;
            }
        }

        // Pause the game and stop the song
        if (e.KeyCode == Keys.Escape)
        {
            // Pause the game 
            if (!isPaused && !game_stop)
            {
                isPaused = true;
                if (!button1.Visible)
                {
                    button1.Visible = true;
                    label2.Visible = true;
                    //button2.Visible = true;
                }
                // Pause the song playback
                Game.GetInstance().CurSong.OutputDevice.Pause();
                wasPlaying = true; // Indicate that the song was playing before pausing
            }
            // Unpause the game 
            else
            {
                game_start_time = DateTime.Now;
                isPaused = false;
                button1.Visible = false;
                label2.Visible=false;
                //button2.Visible = false;
                // Resume the song playback
                if (wasPlaying)
                {
                    Game.GetInstance().CurSong.OutputDevice.Play();
                }
                wasPlaying = false; // Reset the flag
            }
        }
    }
    private void FrmMain_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            var duration = (DateTime.Now - spacePressTime).TotalMilliseconds;
            if (duration < 100)
            {
                isTap = true;
                ProcessNoteHitOrMiss();
            }
            else
            {
                isTap = false;
                isSpacebarHeld = true;
                ProcessNoteMiss();
            }
            picTarget.BackgroundImage = Resources._default;
        }
    }

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        Game.GetInstance().CurSong.Stop();
    }

    private void tmrScoreShrink_Tick(object sender, EventArgs e)
    {
        if (lblScore.Font.Size > 20)
        {
            lblScore.Font = new("Arial", lblScore.Font.Size - 1);
        }
    }

    private void ProcessNoteHitOrMiss()
    {
        bool noteHit = false;
        foreach (var note in notes)
        {
            if (note.CheckHit(picTarget, isTap))
            {
                score.Add(1);
                total_notes_hit += 1;
                lblScore.Text = score.Amount.ToString();
                lblScore.Font = new Font("Arial", 42);
                noteHit = true;
                pictureBox1.BackgroundImage = Properties.Resources.Cherry_Good;
                pictureBox1.BackgroundImageLayout = ImageLayout.Center;


                break;
            }
        }
        if (!noteHit && isTap)
        {
            score.Deduct(1);
            lblScore.Text = score.Amount.ToString();
            pictureBox1.BackgroundImage = Properties.Resources.Cherry_Bad;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;

        }
    }

    private void ProcessNoteMiss()
    {
        score.Deduct(1);
        lblScore.Text = score.Amount.ToString();
        pictureBox1.BackgroundImage = Properties.Resources.Cherry_Bad;
        pictureBox1.BackgroundImageLayout = ImageLayout.Center;

        foreach (var note in notes)
        {
            if (note.CheckMiss(picTarget))
            {
                break;
            }
        }
    }

    private void GameTimer_Tick(object sender, EventArgs e)
    {
        TimeSpan elapsed = DateTime.Now - game_start_time;

        // COLIN: Note that if the player paused at any time, this will not reach the end of the song 
        // Doesn't display total score, but the streak of the notes
        if (elapsed.TotalMilliseconds > curSong.AudioLengthInMs)
        {
            lblScore.Text = score.Amount.ToString() + "/" + notes.Count().ToString();
            tmrPlay.Stop(); // Stop the timer if the song is over
            EndGame();
        }

        if (curSong.OutputDevice.PlaybackState == NAudio.Wave.PlaybackState.Stopped && !isPaused)
        {
            lblScore.Text = score.Amount.ToString() + "/" + notes.Count().ToString();
            tmrPlay.Stop(); // Stop the timer if the song is over
            EndGame();

        }
    }

    private void EndGame()
    {
        game_stop = true;
        button1.Visible = true;
        this.KeyPreview = false;
        Game.GetInstance().CurSong.Stop();
        tmrPlay.Enabled = false;
        game_timer.Enabled = false;
        game_timer.Dispose();
        if (!called_upload)
        {
            OnGameEnd(lblScore.Text.ToString());
        }
    }

    private void OnGameEnd(string score)
    {
        called_upload = true;
        using (var scoreInputForm = new FrmScoreInput())
        {
            scoreInputForm.ShowDialog();
            if (scoreInputForm.UploadScore)
            {
                string playerId = scoreInputForm.PlayerID;
                string tableName = Game.GetInstance().CurSongGenre.ToString(); // Replace with your actual table name
                ScoreTracker.InsertPlayData(tableName, playerId, score);
                MessageBox.Show("Score uploaded successfully!");

                DataTable topScores = ScoreTracker.GetTopScores(tableName);
                DisplayTopScores(topScores);
            }
        }
    }

    private void DisplayTopScores(DataTable topScores)
    {
        string message = "Top 5 Scores:\n";
        foreach (DataRow row in topScores.Rows)
        {
            message += $"PlayerID: {row["PlayerID"]}, Score: {row["Score"]}\n";
        }
        MessageBox.Show(message, "Top Scores");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
        tmrPlay.Enabled = false;
        game_timer.Enabled = false;
        game_timer.Dispose();

    }


}
