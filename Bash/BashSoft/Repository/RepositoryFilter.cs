namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoryFilter
    {
        static Predicate<double> ExcellentFilter = x => x >= 5.00;
        static Predicate<double> AverageFilter = x => 3.5 <= x && x < 5.00;
        static Predicate<double> PoorFilter = x => x < 3.50;

        public void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter.Equals("excellent"))
            {
                FilterAndTake(wantedData, ExcellentFilter, studentsToTake);
            }
            else if (wantedFilter.Equals("average"))
            {
                FilterAndTake(wantedData, AverageFilter, studentsToTake);
            }
            else if (wantedFilter.Equals("poor"))
            {
                FilterAndTake(wantedData, PoorFilter, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int filteredMarksCount = 0;

            foreach (KeyValuePair<string, List<int>> usernamePoints in wantedData)
            {
                if (filteredMarksCount == studentsToTake)
                {
                    break;
                }

                double averageMark = usernamePoints.Value.Average();
                double percentOfTotal = averageMark / 100;
                double mark = percentOfTotal * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(usernamePoints);
                    filteredMarksCount++;
                }
            }
        }
    }
}