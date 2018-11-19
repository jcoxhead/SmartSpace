namespace TestTest.UnitTest
{
    using System;
    using TechTest.Interfaces;

    public class StorableItem : IStoreable
    {
        public string Name { get; set; }
        public IComparable Id { get; set; }
    }
}