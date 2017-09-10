namespace BashSoft.Repository
{
    using Contracts;
    using IO;
    using StaticData;
    using System;
    using System.Collections.Generic;

    public class RepositoryFilter : IDataFilter
    {
        public void FilterAndTake(IDictionary<string, double> studentsWithmarks, string wantedFilter, int studentsToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    this.FilterAndTake(studentsWithmarks, m => 5.0 <= m, studentsToTake);
                    break;

                case "average":
                    this.FilterAndTake(studentsWithmarks, m => 3.5 <= m && m < 5.0, studentsToTake);
                    break;

                case "poor":
                    this.FilterAndTake(studentsWithmarks, m => m < 3.5, studentsToTake);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(IDictionary<string, double> studentsWithmarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var studentMark in studentsWithmarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(studentMark);
                    counterForPrinted++;
                }
            }
        }
    }
}