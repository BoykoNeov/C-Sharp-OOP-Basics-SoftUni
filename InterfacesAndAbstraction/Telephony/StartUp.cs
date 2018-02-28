using System;

public class Startup
{
    public static void Main()
    {
        string[] numbers = Console.ReadLine().Split();
        string[] urls = Console.ReadLine().Split();

        Smartphone phone = new Smartphone();

        foreach (string number in numbers)
        {
            Console.WriteLine(phone.Calling(number));
        }

        foreach (string url in urls)
        {
            Console.WriteLine(phone.Browsing(url));
        }
    }
}