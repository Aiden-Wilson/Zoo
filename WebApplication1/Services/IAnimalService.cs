using ZooApi.Models;

namespace ZooApi.Services
{
    public interface IAnimalService
    {
        Task<List<IAnimal>> GetAllAsync();
        Task<IAnimal?> GetByIdAsync(Guid id);
        Task<IAnimal> AddAsync(string name, string species);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> FeedAnimalAsync(Guid id, int foodAmount);
    }
}
