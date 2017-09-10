namespace BashSoft.Repository
{
    using Contracts;
    using IO;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(IDictionary<string, double> studentsWithmarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            switch (comparison)
            {
                case "ascending":
                    this.PrintStudents(studentsWithmarks.OrderBy(s => s.Value)
                        .Take(studentsToTake)
                        .ToDictionary(p => p.Key, p => p.Value));
                    break;

                case "descending":
                    this.PrintStudents(studentsWithmarks.OrderByDescending(s => s.Value)
                        .Take(studentsToTake)
                        .ToDictionary(p => p.Key, p => p.Value));
                    break;

                default: throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (var student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}