namespace BashSoft
{
    using System.IO;

    public static class SessionData
    {
        private static string currentPath = Directory.GetCurrentDirectory();

        public static string GetCurrentDirectoryPath()
        {
            return currentPath;
        }

        public static void SetCurrentDirectoryPath(string newPath)
        {
            currentPath = newPath;
        }
    }
}