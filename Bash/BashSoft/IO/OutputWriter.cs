namespace BashSoft
{
    using System;
    using System.Collections.Generic;

    public static class OutputWriter
    {
        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteMessageOnNewLine(string message, string parameter)
        {
            Console.WriteLine(string.Format(message, parameter));
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine(Environment.NewLine);
        }

        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void DisplayException(string message, string parameter)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format(message, parameter));
            Console.ForegroundColor = currentColor;
        }

        public static void PrintStudent(KeyValuePair<string, List<int>> student)
        {
            WriteMessageOnNewLine(string.Format($"{student.Key} - {string.Join(", ", student.Value)}"));
        }

        public static void PrintStudents(Dictionary<string, List<int>> students)
        {
            foreach (KeyValuePair<string, List<int>> studentWithMarks in students)
            {
                PrintStudent(studentWithMarks);
            }
        }
    }
}