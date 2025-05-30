using ZooApi.Models;
using ZooApi.Repositories;

namespace ZooApi.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<IAnimal> AddAsync(string name, string species)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым");
            }
            if (species.ToLower() != "lion")
            {
                throw new ArgumentException("Неизвестный вид животного");
            }
            else
            {
                IAnimal animal = new Lion(name, 100);
                await _animalRepository.AddAsync(animal);  
                await _animalRepository.SaveChangesAsync();
                return animal;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _animalRepository.DeleteAsync(id);
            await _animalRepository.SaveChangesAsync();
            return result;
        }

        public async Task<List<IAnimal>> GetAllAsync()
        {
            return await _animalRepository.GetAllAsync();
        }

        public async Task<IAnimal?> GetByIdAsync(Guid id)
        {
            return await _animalRepository.GetByIdAsync(id);
        }

        public async Task<bool> FeedAnimalAsync(Guid id, int foodAmount)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null)
                return false;
            else
            {
                animal.Eat(foodAmount);;
                await _animalRepository.SaveChangesAsync();
                return true;
            }
        }
    }
}
