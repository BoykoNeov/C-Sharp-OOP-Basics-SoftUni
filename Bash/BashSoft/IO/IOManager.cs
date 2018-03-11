namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class IOManager
    {
        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.GetCurrentDirectoryPath();
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.SetCurrentDirectoryPath(newPath);
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }

            }
            else
            {
                string currentPath = SessionData.GetCurrentDirectoryPath();
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }

            SessionData.SetCurrentDirectoryPath(absolutePath);
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.GetCurrentDirectoryPath() + "\\" + name;

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (NotSupportedException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }

        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.GetCurrentDirectoryPath().Split(new char[] { '\\' }).Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.GetCurrentDirectoryPath());

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split(new char[] { '\\' }).Length - initialIdentation;

                if (depth - identation < 0)
                {
                    break;
                }

                OutputWriter.WriteMessageOnNewLine(new string('-', identation) + currentPath);

                try
                {
                    foreach (string file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
        }
    }
}