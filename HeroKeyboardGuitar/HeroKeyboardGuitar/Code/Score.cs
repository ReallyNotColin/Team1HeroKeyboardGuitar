using System;

namespace HeroKeyboardGuitar;

/// <summary>
/// Holds the current score and streak of the player
/// </summary>
public class Score {
    /// <summary>
    /// Amount of notes successfully hit
    /// </summary>
    public int Amount { get; private set; }

    /// <summary>
    /// Current streak, i.e. consecutive hit notes without a miss
    /// </summary>
   
    public Score() {
        Amount = 0;
    }

    /// <summary>
    /// Used to check if the player has reached the point of receiving a reward.
    /// Currently not implemented
    /// </summary>
    public void CheckReward() {
        // TODO: possibly make this a dictionary mapping genres to reward maps
        //Game.GetRewardMap()
    }

    /// <summary>
    /// Add to the current score
    /// </summary>
    /// <param name="amount">Amount to add</param>
    public void Add(int amount) {
        Amount += amount;
    }

    /// <summary>
    /// Deducts points when note is missed
    /// </summary>
 
    public void Deduct(int amount) {
        Amount = Math.Max(0, Amount - amount);
    }
}
