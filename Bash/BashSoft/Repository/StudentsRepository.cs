namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class StudentsRepository
    {
        public bool isDataInitialized = false;
        internal Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                sorter.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                filter.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public void LoadData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
                return;
            }
        }

        public void UnloadData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            this.isDataInitialized = false;
        }

        public void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private void ReadData()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(input))
            {
                InputEntryIntoDB(input);
            }

            this.isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read");
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.GetCurrentDirectoryPath() + "\\" + fileName;

            if (File.Exists(path))
            {
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    InputEntryIntoDB(allInputLines[line]);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read");
        }

        private void InputEntryIntoDB(string inputLine)
        {
            string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
            Regex rgx = new Regex(pattern);

            if (!string.IsNullOrWhiteSpace(inputLine) && rgx.IsMatch(inputLine))
            {
                Match currentMatch = rgx.Match(inputLine);

                string courseName = currentMatch.Groups[1].Value;
                string student = currentMatch.Groups[2].Value;


                bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out int studentScoreOnTask);

                if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                {
                    if (!studentsByCourse.ContainsKey(courseName))
                    {
                        studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                    }

                    if (!studentsByCourse[courseName].ContainsKey(student))
                    {
                        studentsByCourse[courseName].Add(student, new List<int>());
                    }

                    studentsByCourse[courseName][student].Add(studentScoreOnTask);
                }
            }
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }

            return false;
        }

        public void GetStudentScoresFromCourse(string coursename, string username)
        {
            if (IsQueryForStudentPossible(coursename, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[coursename][username]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (KeyValuePair<string, List<int>> studentMarkEntry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentMarkEntry);
                }
            }
        }
    }
}