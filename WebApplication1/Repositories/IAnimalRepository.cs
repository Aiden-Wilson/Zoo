using ZooApi.Models;

namespace ZooApi.Repositories
{
    public interface IAnimalRepository
    {
        Task<List<IAnimal>> GetAllAsync();
        Task<IAnimal?> GetByIdAsync(Guid id);
        Task AddAsync(IAnimal animal);
        Task<bool> DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
