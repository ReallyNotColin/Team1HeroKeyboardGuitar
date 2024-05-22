using AudioAnalyzing;
using HeroKeyboardGuitar.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HeroKeyboardGuitar;

internal partial class FrmMain : Form {
    private List<Note> notes;
    private const float noteSpeed = 0.35f;
    private Audio curSong;
    private Score score;
    public bool isSpacebarHeld = false;
    private bool isTap = false;
    private DateTime spacePressTime;

    // COLIN: Try to get the game to pause 
    public bool isPaused = false;


    // for double buffering
    protected override CreateParams CreateParams {
        get {
            var cp = base.CreateParams;
            cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
            return cp;
        }
    }

    public FrmMain() {
        InitializeComponent();
    }

    public void FrmMain_Load(object sender, EventArgs e) {
        score = new();
        lblScore.Text = score.Amount.ToString();
        panBg.BackgroundImage = Game.GetInstance().GetBg();
        panBg.Height = (int)(Height * 0.8);
        curSong = Game.GetInstance().CurSong;
        notes = new();
        foreach (var actionTime in curSong.ActionTimes) {
            double x = actionTime * noteSpeed + picTarget.Left + picTarget.Width;
            const int noteSize = 50;
            if (notes.Any(note => (x - note.Pic.Left) < noteSize / 2)) {
                continue;
            }
            // Create note 
            PictureBox picNote = new() {
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
        // Create timer for brief pause at beginning 
        Timer tmrWaitThenPlay = new() {
            Interval = 1000,
            Enabled = true,
        };
        // Add timer for brief pause at beginning 
        components.Add(tmrWaitThenPlay);
        // 
        tmrWaitThenPlay.Tick += (e, sender) => {
            Game.GetInstance().CurSong.Play();
            tmrWaitThenPlay.Enabled = false;
            tmrPlay.Enabled = true;
        };
    }

    private void tmrPlay_Tick(object sender, EventArgs e) {
        int index = curSong.GetPosition();
        foreach (var note in notes) {
           
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
        if (index >= curSong.GetNumberOfSamples() - 1) {
            tmrPlay.Enabled = false;
            foreach (var note in notes) {
                Controls.Remove(note.Pic);
                note.Dispose();
            }
        }
    }

    private void FrmMain_KeyPress(object sender, KeyPressEventArgs e) {
        
    }

    /// <summary>
    ///  USER INPUT KEY CONTROLS 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FrmMain_KeyDown(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Space) {
            spacePressTime = DateTime.Now;
            isSpacebarHeld = false;
            picTarget.BackgroundImage = Resources.pressed;
        }
        // COLIN: Currently closes the form. Change this to pause the game.
        if (e.KeyCode == Keys.Escape)
        {
            // hard to stop a foreach statement with another foreach statement....
            // Will revist this when sober 
            if (!isPaused)
            {
                isPaused = true;
                Game.GetInstance().CurSong.Stop();
            }
            else
            {
                isPaused = false;
                Game.GetInstance().CurSong.Play();

            }
        }
    }

    private void FrmMain_KeyUp(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Space) {
            var duration = (DateTime.Now - spacePressTime).TotalMilliseconds;
            if (duration < 100) {
                isTap = true;
                ProcessNoteHitOrMiss();
            }
            else {
                isTap = false;
                isSpacebarHeld = true;
                ProcessNoteMiss();
            }
            picTarget.BackgroundImage = Resources._default;
        }
    }

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
        Game.GetInstance().CurSong.Stop();
    }

    private void tmrScoreShrink_Tick(object sender, EventArgs e) {
        if (lblScore.Font.Size > 20) {
            lblScore.Font = new("Arial", lblScore.Font.Size - 1);
        }
    }

    private void ProcessNoteHitOrMiss() {
        bool noteHit = false;
        foreach (var note in notes) {
            if (note.CheckHit(picTarget, isTap)) {
                score.Add(1);
                lblScore.Text = score.Amount.ToString();
                lblScore.Font = new Font("Arial", 42);
                noteHit = true;
                break;
            }
        }
        if (!noteHit && isTap) {
            score.Deduct(1);
            lblScore.Text = score.Amount.ToString();
        }
    }

    private void ProcessNoteMiss() {
        score.Deduct(1);
        lblScore.Text = score.Amount.ToString();

        foreach (var note in notes) {
            if (note.CheckMiss(picTarget)) {
                break;
            }
        }
    }
}
