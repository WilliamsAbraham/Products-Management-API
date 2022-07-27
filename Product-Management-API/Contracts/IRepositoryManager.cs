namespace Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository? Product{ get; }
        IAppAdminRepository? AppAdmin{ get; }
        Task Save();
    }
}
