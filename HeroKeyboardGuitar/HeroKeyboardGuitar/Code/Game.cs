using AudioAnalyzing;
using HeroKeyboardGuitar.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace HeroKeyboardGuitar;

/// <summary>
/// Holds 
/// </summary>
public class Game {
    private Dictionary<GenreType, Bitmap> bgMap;

    /// <summary>
    /// Current song being played
    /// </summary>
    public Audio CurSong { get; private set; }

    /// <summary>
    /// Current genre of the song being played
    /// </summary>
    public GenreType CurSongGenre { get; private set; }

    private static Game instance = new();

    private Game() {
        bgMap = new() {
            [GenreType.CLASSICAL] = Resources.classical,
            [GenreType.COUNTRY] = Resources.country,
            [GenreType.METAL] = Resources.metal,
            [GenreType.POP] = Resources.pop,
            [GenreType.RNB] = Resources.rnb,
            [GenreType.ROCK] = Resources.rock,
        };
    }

    /// <summary>
    /// Grabs the singleton instance
    /// </summary>
    /// <returns>The singleton instance</returns>
    public static Game GetInstance() {
        return instance;
    }

    /// <summary>
    /// Retrieves the map of rewards for scores.
    /// Current not used
    /// </summary>
    /// <returns>Map of rewards by score</returns>
    public static Dictionary<int, Action> GetRewardMap() {
        //return instance.CurSong.re
        return null;
    }

    /// <summary>
    /// Retrieves the background image associated with the current song's genre
    /// </summary>
    /// <returns>A background image</returns>
    public Bitmap GetBg() {
        return bgMap.GetValueOrDefault(CurSongGenre, null);
    }

    /// <summary>
    /// Retrieves the background image for the given genre
    /// </summary>
    /// <param name="genre">Genre to use</param>
    /// <returns>A background image</returns>
    public static Bitmap GetBg(GenreType genre) {
        return instance.bgMap[genre];
    }

    /// <summary>
    /// Creates an Audio object based on the given file path and holds the given genre so we can refer to both later
    /// </summary>
    /// <param name="songFilePath">Full absolute path to a wav file</param>
    /// <param name="genre">Genre of the song</param>
    public static void SetCurSong(string songFilePath, GenreType genre) {
        instance.CurSong = new(songFilePath);
        instance.CurSongGenre = genre;
    }
}
