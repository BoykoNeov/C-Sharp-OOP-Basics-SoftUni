using System;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        try
        {
            Box box = new Box(length, width, height);

            sb.AppendLine($"Surface Area - {box.GetSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {box.GetVolume():F2}");
        }
        catch(Exception e)
        {
            sb.AppendLine(e.Message);
        }
        finally
        {
            Console.WriteLine(sb.ToString());
        }
    }
}