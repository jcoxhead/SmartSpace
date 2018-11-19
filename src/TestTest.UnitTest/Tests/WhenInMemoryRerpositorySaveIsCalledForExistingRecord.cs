namespace TestTest.UnitTest.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using TechTest.Interfaces;

    [TestFixture]
    public class WhenInMemoryRerpositorySaveIsCalledForExistingRecord : InMemoryRepositoryBase
    {
        [SetUp]
        public void Setup()
        {
            GivenInmemoryRepositoryExistsAndIsInitialised();
            WhenSystemSavesRecord();
        }

        private IRepository<StorableItem> _repository;
        private IEnumerable<StorableItem> _result;
        private StorableItem _itemToBeSaved;

        public void GivenInmemoryRepositoryExistsAndIsInitialised()
        {
            _repository = GetRepository();

            _itemToBeSaved = Builder<StorableItem>
                .CreateNew()
                .With(q => q.Id = 1)
                .Build();

            _repository.Save(_itemToBeSaved);
        }

        public void WhenSystemSavesRecord()
        {
            _repository.Save(_itemToBeSaved);
        }

        [Test]
        public void ThenInMemoryRepositoryListShouldContainOneMatchingRecord()
        {
            _result = _repository.All().Where(q => q.Id.Equals(_itemToBeSaved.Id));
            _result.Count().Should().Be(1);
        }

        [Test]
        public void ThenInMemoryRepositoryListShouldHaveSavedObject()
        {
            _result = _repository.All();
            _result.Contains(_itemToBeSaved).Should().BeTrue();
        }
    }
}