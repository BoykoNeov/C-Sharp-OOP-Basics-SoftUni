internal class Song
{
    private string name;
    private string artist;
    private int songMinutes;
    private int songSeconds;

    internal Song()
    {
    }

    internal Song(string artistName, string songName, int minutes, int seconds)
    {
        this.Artist = artistName;
        this.Name = songName;
        this.SongMinutes = minutes;
        this.SongSeconds = seconds;
    }

    public int SongSeconds
    {
        get
        {
            return songSeconds;
        }
        set
        {
            if (!Validator.IsSongSecondsValueValid(value))
            {
                Messages.InvalidSongSecondsException();
            }

            songSeconds = value;
        }
    }

    public int SongMinutes
    {
        get
        {
            return songMinutes;
        }
        set
        {
            if (!Validator.IsSongMinutesValueValid(value))
            {
                Messages.InvalidSongMinutesException();
            }

            songMinutes = value;
        }
    }

    public string Artist
    {
        get
        {
            return artist;
        }
        set
        {
            if (!Validator.IsArtistNameValid(value))
            {
                Messages.InvalidArtistNameException();
            }

            artist = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (!Validator.IsSongNamevalid(value))
            {
                Messages.InvalidSongNameException();
            }

            name = value;
        }
    }
}