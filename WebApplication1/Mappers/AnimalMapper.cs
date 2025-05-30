using ZooApi.Data.Entities;
using ZooApi.Models;

namespace ZooApi.Mappers
{
    public static class AnimalMapper
    {
        public static IAnimal ToAnimal(AnimalEntity entity)
        {
            return entity.Species.ToLower() switch
            {
                "lion" => new Lion(entity) { Name = entity.Name, EnergyLevel = entity.EnergyLevel },
                _ => throw new Exception("Неизвестный вид животного")
            };
        }

        public static AnimalEntity ToAnimalEntity(IAnimal animal)
        {
            return new AnimalEntity 
            { 
                EnergyLevel = animal.EnergyLevel,
                Name = animal.Name,
                Id = animal.Id,
                Species = animal.GetType().Name.ToLower() 
            };
        }
    }
}
