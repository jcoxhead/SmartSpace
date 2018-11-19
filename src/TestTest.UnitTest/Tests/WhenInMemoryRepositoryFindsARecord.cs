namespace TestTest.UnitTest.Tests
{
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;
    using TechTest.Interfaces;

    [TestFixture]
    public class WhenInMemoryRepositoryFindsARecord : InMemoryRepositoryBase
    {
        [SetUp]
        public void Setup()
        {
            GivenInmemoryRepositoryExistsAndIsInitialised();
            WhenSystemFindsARecord();
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

        public void WhenSystemFindsARecord()
        {
            _result = _repository.FindById(1);
        }

        [Test]
        public void ThenInMemoryRepositoryShouldReturnARecord()
        {
            _result.Should().NotBe(null);
        }

        [Test]
        public void ThenInMemoryRepositoryShouldReturnCorrectRecord()
        {
            _result.Id.Should().Be(_itemToSave.Id);
        }
    }
}