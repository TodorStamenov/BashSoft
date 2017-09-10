namespace BashSoft.Contracts
{
    using System.Collections.Generic;

    public interface IDataSorter
    {
        void OrderAndTake(IDictionary<string, double> studentsWithmarks, string comparison, int studentsToTake);
    }
}