namespace TestTest.UnitTest.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;
    using TechTest.Interfaces;

    [TestFixture]
    public class WhenInMemoryRepositoryListReturnsNoRecords : InMemoryRepositoryBase
    {
        [SetUp]
        public void Setup()
        {
            GivenInmemoryRepositoryExists();
        }

        private IRepository<StorableItem> _repository;
        private IEnumerable<StorableItem> _result;

        public void GivenInmemoryRepositoryExists()
        {
            _repository = GetRepository();

            WhenSystemRequestsAllRecords();
        }

        public void WhenSystemRequestsAllRecords()
        {
            _result = _repository.All();
        }

        [Test]
        public void ThenInMemoryRepositoryListShouldReturnIEnumerableOfCorrectType()
        {
            _result.Should().BeAssignableTo<IEnumerable<StorableItem>>();
        }

        [Test]
        public void ThenInMemoryRepositoryListShouldContainTheCorrectNumberOPfRecords()
        {
            _result.Count().Should().Be(0);
        }
    }
}