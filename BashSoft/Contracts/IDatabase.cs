﻿namespace BashSoft.Contracts
{
    public interface IDatabase : IOrderedTaker, IFilteredTaker, IRequester
    {
        void LoadData(string fileName);

        void UnloadData();
    }
}