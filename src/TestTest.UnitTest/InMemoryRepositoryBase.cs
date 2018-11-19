namespace TestTest.UnitTest
{
    using TechTest;
    using TechTest.Interfaces;

    public class InMemoryRepositoryBase
    {
        protected IRepository<StorableItem> GetRepository()
        {
            return new Repository<StorableItem>();
        }
    }
}