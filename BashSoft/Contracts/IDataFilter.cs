namespace BashSoft.Contracts
{
    using System.Collections.Generic;

    public interface IDataFilter
    {
        void FilterAndTake(IDictionary<string, double> studentsWithmarks, string wantedFilter, int studentsToTake);
    }
}