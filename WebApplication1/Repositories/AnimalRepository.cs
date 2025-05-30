using Microsoft.EntityFrameworkCore;
using ZooApi.Data;
using ZooApi.Data.Entities;
using ZooApi.Mappers;
using ZooApi.Models;

namespace ZooApi.Repositories
{
    public class AnimalRepository :  IAnimalRepository
    {
        private readonly ZooContext _context;
        public AnimalRepository (ZooContext context)
        {
            _context = context;
        }

        public async Task AddAsync(IAnimal animal)
        {
           await _context.Animals.AddAsync(AnimalMapper.ToAnimalEntity(animal));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity =  await _context.Animals.FindAsync(id);
            if (entity == null) return false;

            _context.Animals.Remove(entity);
            return true;
        }

        public async Task<List<IAnimal>> GetAllAsync()
        {
            var entities = await _context.Animals.ToListAsync<AnimalEntity>();
            return entities
                .Select(AnimalMapper.ToAnimal)
                .ToList();
        }
        public async Task<IAnimal?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Animals.FindAsync(id);

            return entity is null ? null : AnimalMapper.ToAnimal(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
