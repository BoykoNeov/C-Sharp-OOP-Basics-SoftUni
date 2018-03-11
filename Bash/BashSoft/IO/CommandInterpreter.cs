namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;

    public class CommandInterpreter
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        private bool ValidateCommandLength(string command, IEnumerable<string> commandParams, int commandParamsCount)
        {
            if (commandParams.Count() != commandParamsCount)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidCommand, command);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void InterpredCommand(string input)
        {
            List<string> commandParameters = input.Split().ToList();
            string command = commandParameters[0].ToLower();
            commandParameters.RemoveAt(0);

            switch (command)
            {
                case "open":
                    if (ValidateCommandLength(command, commandParameters, 1))
                    {
                        OpenFile(commandParameters);
                    }

                    break;

                case "mkdir":
                    if (ValidateCommandLength(command, commandParameters, 1))
                    {
                        CreateDirectory(input, commandParameters);
                    }

                    break;

                case "ls":
                    if (commandParameters.Count() != 0)
                    {
                        if (!ValidateCommandLength(input, commandParameters, 1))
                        {
                            break;
                        }
                        else
                        {
                            bool hasParsed = int.TryParse(commandParameters[0], out int depth);

                            if (hasParsed)
                            {
                                inputOutputManager.TraverseDirectory(depth);
                            }
                            else
                            {
                                OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                            }
                        }
                    }
                    else
                    {
                        inputOutputManager.TraverseDirectory(0);
                    }


                    break;

                case "cmp":
                    if (ValidateCommandLength(command, commandParameters, 2))
                    {
                        CompareFiles(commandParameters);
                    }

                    break;

                case "cdrel":
                    if (ValidateCommandLength(command, commandParameters, 1))
                    {
                        ChangeDirectoryRelative(commandParameters);
                    }

                    break;

                case "cdabs":
                    if (ValidateCommandLength(command, commandParameters, 1))
                    {
                        ChangeDirectoryAbsolute(commandParameters);
                    }

                    break;
                case "readdb":
                    if (ValidateCommandLength(command, commandParameters, 1))
                    {
                        ReadDatabaseFromFile(commandParameters);
                    }

                    break;

                case "help":
                    DisplayHelp();
                    break;

                case "filter":
                    if (ValidateCommandLength(command, commandParameters, 4))
                    {
                            string courseName = commandParameters[0];
                            string filter = commandParameters[1].ToLower();
                            string takeCommand = commandParameters[2].ToLower();
                            string takeQuantity = commandParameters[3].ToLower();

                            TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
                    }

                    break;

                case "order":
                    if (ValidateCommandLength(command, commandParameters, 4))
                    {
                        string courseName = commandParameters[0];
                        string orderType = commandParameters[1].ToLower();
                        string orderCommand = commandParameters[2].ToLower();
                        string orderQuantity = commandParameters[3].ToLower();

                        TryParseParametersForOrderAndTake(orderCommand, orderQuantity, courseName, orderType);
                    }
                    break;

                case "download":
                    if (ValidateCommandLength(command, commandParameters, 2))
                    {
                        DownloadFile(commandParameters);
                    }
                    
                    break;

                case "downloadasynch":
                    DownloadFileAsync(commandParameters);
                    break;

                case "show":
                    TryShowWantedData(commandParameters, command);
                    break;

                case "dropdb":
                    if (ValidateCommandLength(command, commandParameters, 0))
                    {
                        TryDrobDb(commandParameters.ToArray());
                    }
                    break;

                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidCommand, (input));
                    break;
            }
        }

        private void DownloadFileAsync(List<string> commandParameters)
        {
            using (WebClient client = new WebClient())
            {
                string fileAddress = commandParameters[0];
                string saveAddress = commandParameters[1];

                var uri = new Uri(fileAddress);

                client.DownloadFileCompleted += (sender, e) => OutputWriter.WriteMessageOnNewLine("Finished downloading file");
                client.DownloadFileAsync(uri, saveAddress);
            }

        }

        /// <summary>
        /// Downloads a file from a link
        /// </summary>
        /// <param name="commandParameters">requires string[2], first is the file address, second is the save address</param>
        private void DownloadFile(List<string> commandParameters)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string fileAddress = commandParameters[0];
                    string saveAddress = commandParameters[1];

                    client.DownloadFile(fileAddress, saveAddress);
                    OutputWriter.WriteMessageOnNewLine(@"The file was downloaded here: {0}", saveAddress);
                }
            }
            catch
            {
                OutputWriter.DisplayException(ExceptionMessages.ErrorDownloadingFile);
            }
        }

        private void TryParseParametersForOrderAndTake(string orderCommand, string orderQuantity, string courseName, string orderType)
        {
            if (orderCommand.Equals("take"))
            {
                if (orderQuantity.Equals("all"))
                {
                    repository.OrderAndTake(courseName, orderType);
                }
                else
                {
                    bool hasParsed = int.TryParse(orderQuantity, out int studentsToTake);

                    if (hasParsed)
                    {
                        repository.OrderAndTake(courseName, orderType, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand.Equals("take"))
            {
                if (takeQuantity.Equals("all"))
                {
                    repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    bool hasParsed = int.TryParse(takeQuantity, out int studentsToTake);
                    if (hasParsed)
                    {
                        repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private void DisplayHelp()
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdrel:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdabs:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "dropdb – drops the database"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private void TryShowWantedData(List<string> commandParameters, string command)
        {
            if (commandParameters.Count() == 1)
            {
                string courseName = commandParameters[0];
                repository.GetAllStudentsFromCourse(courseName);
            }
            else if (commandParameters.Count() == 2)
            {
                string courseName = commandParameters[0];
                string userName = commandParameters[1];
                repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                OutputWriter.DisplayException(command, ExceptionMessages.InvalidCommand);
            }
        }

        private void TryDrobDb(string[] data)
        {
            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }

        private void ReadDatabaseFromFile(List<string> commandParameters)
        {
            string fileName = commandParameters[0];
            repository.InitializeData(fileName);
        }

        private void ChangeDirectoryAbsolute(List<string> commandParameters)
        {
            string absolutePath = commandParameters[0];
            inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }

        private void ChangeDirectoryRelative(List<string> commandParameters)
        {
            string relativePath = commandParameters[0];
            inputOutputManager.ChangeCurrentDirectoryRelative(relativePath);
        }

        private void CompareFiles(List<string> commandParameters)
        {
            string firstPath = commandParameters[0];
            string secondPath = commandParameters[1];

            judge.CompareContent(firstPath, secondPath);
        }

        private void CreateDirectory(string input, List<string> commandParameters)
        {
            string directoryName = commandParameters[0];
            inputOutputManager.CreateDirectoryInCurrentFolder(directoryName);
        }

        private void OpenFile(List<string> commandParameters)
        {
            string fileName = commandParameters[0];
            fileName = SessionData.GetCurrentDirectoryPath() + "\\" + fileName;

            try
            {
                Process.Start(fileName);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }
    }
}
