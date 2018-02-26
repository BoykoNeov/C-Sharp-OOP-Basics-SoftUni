public static class MoodFactory
{
    public static Mood CreateMood(int happiness)
    {
        Mood newMood = null;

        if (happiness < -5)
        {
            newMood = new Angry();
        }
        else if(happiness <= 0)
        {
            newMood = new Sad();
        }
        else if(happiness < 15)
        {
            newMood = new Happy();
        }
        else
        {
            newMood = new JavaScript();
        }

        return newMood;
    }
}