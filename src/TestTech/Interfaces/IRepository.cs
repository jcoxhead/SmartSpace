﻿namespace TechTest.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T> where T : IStoreable
    {
        IEnumerable<T> All();
        void Delete(IComparable id);
        void Save(T item);
        T FindById(IComparable id);
    }
}
