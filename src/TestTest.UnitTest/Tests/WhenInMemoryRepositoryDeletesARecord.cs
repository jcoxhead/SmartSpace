namespace TestTest.UnitTest.Tests
{
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using TechTest.Interfaces;

    [TestFixture]
    public class WhenInMemoryRepositoryDeletesARecord : InMemoryRepositoryBase
    {
        [SetUp]
        public void Setup()
        {
            GivenInmemoryRepositoryExistsAndIsInitialised();
            WhenSystemDeletesARecord();
        }

        private IRepository<StorableItem> _repository;
        private StorableItem _result;
        private StorableItem _itemToSave;

        public void GivenInmemoryRepositoryExistsAndIsInitialised()
        {
            _repository = GetRepository();

            _itemToSave = Builder<StorableItem>
                .CreateNew()
                .With(q => q.Id = 1)
                .Build();

            _repository.Save(_itemToSave);
        }

        public void WhenSystemDeletesARecord()
        {
            _repository.Delete(_itemToSave.Id);
        }

        [Test]
        public void ThenInMemoryRepositoryShouldReturnARecord()
        {
            _result = _repository.FindById(_itemToSave.Id);
            _result.Should().Be(null);
        }
    }
}