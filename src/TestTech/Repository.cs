namespace TechTest
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private readonly List<T> _entities;

        public Repository()
        {
            _entities = new List<T>();
        }

        public IEnumerable<T> All()
        {
            return _entities;
        }

        public void Delete(IComparable id)
        {
            _entities.RemoveAll(WhereMatches(id));
        }

        public void Save(T item)
        {
            Delete(item.Id); // Avoid Duplicate
            _entities.Add(item);
        }

        public T FindById(IComparable id)
        {
            return _entities.Find(WhereMatches(id));
        }

        private Predicate<T> WhereMatches(IComparable id)
        {
            return match => match.Id.Equals(id);
        }
    }
}