using System.Collections.Generic;

public class TyreFactory
{
    public static Tyre CreateInstance(List<string> args)
    {
        try
        {
            Tyre newTyre = null;

            if (args[0] == "Ultrasoft")
            {
                newTyre = new UltrasoftTyre(double.Parse(args[1]), double.Parse(args[2]));
            }
            else
            {
                newTyre = new HardTyre(double.Parse(args[1]));
            }

            return newTyre;
        }
        catch
        {
            return null;
        }
    }
}