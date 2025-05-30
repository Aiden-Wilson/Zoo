using ZooApi.Data.Entities;

namespace ZooApi.Models
{
    class Lion : Animal
    {
        public Lion(string name, int energyLevel) : base()
        {
            Name = name;
            EnergyLevel = energyLevel;
        }

        public Lion(AnimalEntity entity) : base(entity.Id)
        {
            Name = entity.Name;
            EnergyLevel = entity.EnergyLevel;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Rrrr!");
        }
    }
}
