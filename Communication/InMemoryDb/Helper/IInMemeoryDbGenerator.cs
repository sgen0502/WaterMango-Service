namespace WaterMango_Service.Communication.InMemoryDb.Helper
{
    public interface IInMemeoryDbGenerator<T> where T : class
    {
        InMemoryDbContext<T> BuildDb();
    }
}