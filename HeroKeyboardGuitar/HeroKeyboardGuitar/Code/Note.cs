using HeroKeyboardGuitar.Properties;
<<<<<<< Updated upstream
=======
using System;
using System.Diagnostics.Eventing.Reader;
>>>>>>> Stashed changes
using System.Windows.Forms;

namespace HeroKeyboardGuitar;

/// <summary>
/// The status of the moving note
/// </summary>
public enum NoteState {
    /// <summary>
    /// Still moving towards the target. Hasn't been hit nor missed yet
    /// </summary>
    TRAVELING,

    /// <summary>
    /// Successfully hit
    /// </summary>
    HIT,

    /// <summary>
    /// Missed
    /// </summary>
    MISS,
}

/// <summary>
/// Holds a single note in a song, as well as the picture for that note.
/// Handles movement, hitting and missing
/// </summary>
public class Note {
    /// <summary>
    /// Current state of the note
    /// </summary>
    public NoteState State { get; private set; }

    /// <summary>
    /// Image shown to player
    /// </summary>
    public PictureBox Pic { get; private set; }

    private double xPos;

    /// <summary>
    /// Ctor. Sets state to traveling
    /// </summary>
    /// <param name="pic">PictureBox for visual representation</param>
    /// <param name="xPos">Starting x position</param>
    public Note(PictureBox pic, double xPos) {
        Pic = pic;
        State = NoteState.TRAVELING;
        this.xPos = xPos;
    }

    /// <summary>
    /// Destroys picture box
    /// </summary>
    public void Dispose() {
        Pic.Dispose();
    }

    /// <summary>
    /// Moves note to the left by amount. Send a positive amount and 
    /// x position is subtracted by this amount. Also moves picture box.
    /// </summary>
    /// <param name="amount">Amount to move to the left</param>
    public void Move(double amount) {
        xPos -= amount;
        Pic.Left = (int)xPos;
    }
<<<<<<< Updated upstream
=======
    
    /// <summary>
    /// STOP THE NOTE FROM MOVING 
    /// </summary>
    public void Pause()
    {
        xPos -= 0;
        Console.WriteLine("PAUSED");

    }
>>>>>>> Stashed changes

    /// <summary>
    /// Checks if the player has successfully hit this note. If so, the note will be marked as hit and
    /// picture box and state will reflect this.
    /// </summary>
    /// <param name="picTarget">PictureBox object for player's target zone</param>
    /// <returns>True if note was just hit, false if it wasn't hit or was already previously hit</returns>
    public bool CheckHit(PictureBox picTarget) {
        if (Pic.Left < picTarget.Left + picTarget.Width && Pic.Left + Pic.Width > picTarget.Left && State == NoteState.TRAVELING) {
            Pic.BackgroundImage = Resources.marker_hit;
            State = NoteState.HIT;
            return true;
        }
        else {
            return false;
        }
    }

    /// <summary>
    /// Checks if the player has missed this note. If so, the note will be marked as missed and
    /// picture box and state will reflect this.
    /// </summary>
    /// <param name="picTarget">PictureBox object for player's target zone</param>
    /// <returns>True if note was just missed, false if it wasn't missed or was already previously missed</returns>
    public bool CheckMiss(PictureBox picTarget) {
        if (Pic.Left < picTarget.Left && State == NoteState.TRAVELING) {
            Pic.BackgroundImage = Resources.marker_miss;
            State = NoteState.MISS;
            return true;
        }
        else {
            return false;
        }
    }
}
