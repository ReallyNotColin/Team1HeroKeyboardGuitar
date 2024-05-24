using System;
using System.Drawing;
using System.Windows.Forms;

namespace HeroKeyboardGuitar
{
    public partial class FrmInstructions : Form
    {
        private Label instructionsLabel;

        public FrmInstructions()
        {
            instructionsLabel = new Label();
            instructionsLabel.Text = "How to Play:\n\n" +
                                        "1. Select a song and difficulty from the drop-down menu.\n" +
                                        "2. Press 'f' to begin the game.\n" +
                                        "3. Press 'Esc' to pause the game. \n" +
                                        "4. Time the space bar presses until the note reaches the green circle to make Cherry happy.\n" +
                                        "5. Have fun!";
            instructionsLabel.AutoSize = true;
            instructionsLabel.Font = new Font("Arial", 12); // Change font and size
            instructionsLabel.TextAlign = ContentAlignment.MiddleLeft; // Align text to left
            instructionsLabel.Padding = new Padding(10); // Add padding around the label

            this.Controls.Add(instructionsLabel);

            this.Text = "Instructions";
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoSize = true;
        }
    }
}
