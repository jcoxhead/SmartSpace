namespace TestTest.UnitTest.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using TechTest.Interfaces;

    [TestFixture]
    public class WhenInMemoryRepositoryListReturnsAllRecords : InMemoryRepositoryBase
    {
        [SetUp]
        public void Setup()
        {
            GivenInmemoryRepositoryExistsAndIsInitialised();
            WhenSystemRequestsAllRecords();
        }

        private IRepository<StorableItem> _repository;
        private IEnumerable<StorableItem> _result;
        private readonly int totalRecordCount = 3;

        public void GivenInmemoryRepositoryExistsAndIsInitialised()
        {
            _repository = GetRepository();

            var itemNumber = 0;
            var testStorableItems = Builder<StorableItem>
                .CreateListOfSize(totalRecordCount)
                .All()
                .With(q => q.Id = itemNumber++)
                .Build();

            for (itemNumber = 0; itemNumber < testStorableItems.Count; itemNumber++)
                _repository.Save(testStorableItems[itemNumber]);
        }

        public void WhenSystemRequestsAllRecords()
        {
            _result = _repository.All();
        }

        [Test]
        public void ThenInMemoryRepositoryListShouldContainTheCorrectNumberOPfRecords()
        {
            _result.Count().Should().Be(totalRecordCount);
        }

        [Test]
        public void ThenInMemoryRepositoryListShouldReturnIEnumerableOfCorrectType()
        {
            _result.Should().BeAssignableTo<IEnumerable<StorableItem>>();
        }
    }
}