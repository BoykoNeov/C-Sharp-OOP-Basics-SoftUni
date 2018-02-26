using System.Collections.Generic;
using System.Linq;

internal class Playlist
{
    internal List<Song> allSongs;

    internal Playlist(int expectedSongCount = Constants.expectedTotalSongsCount)
    {
        this.allSongs = new List<Song>(expectedSongCount);
    }

    internal void AddSong(Song newSong)
    {
        this.allSongs.Add(newSong);
    }

    internal int SongCount()
    {
        return this.allSongs.Count;
    }

    internal int TotalLengthInSeconds()
    {
        int totalMinutesSumInSeconds = this.allSongs.Select(x => x.SongMinutes).Sum() * 60;
        int totalSecondsSum = this.allSongs.Select(x => x.SongSeconds).Sum();
        int result = totalMinutesSumInSeconds + totalSecondsSum;

        return result;
    }
}