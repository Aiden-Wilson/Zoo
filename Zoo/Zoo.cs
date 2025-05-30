using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooManagment
{
    interface IAnimal
    {
        string Name { get; set; }
        int EnergyLevel { get; set; }
        void MakeSound();
        void Eat();
    }
    abstract class Animal : IAnimal
    {
        private int _energyLevel;
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "Имя не может быть null");
                else 
                    _name = value;
            }

        }
        public int EnergyLevel
        {
            get => _energyLevel;
            set => _energyLevel = value > 100 ? 100 : value;
        }
        public virtual void Eat(int energyGain = 1)
        {
            EnergyLevel += energyGain;
        }
        void IAnimal.Eat()
        {
            Eat();
        }
        public abstract void MakeSound();
    }

    class Lion : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Rrrr!");
        }
        public override void Eat(int energyGain = 1)
        {
            base.Eat(energyGain);
            MakeSound();
        }
    }
    class Zoo
    {
        List<IAnimal> animals;
        public int AnimalsCount => animals.Count;
        public Zoo()
        {
            animals = new List<IAnimal>();
        }
        public void AddAnimal(IAnimal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal), "Животное не может быть null");
            animals.Add(animal);
        }
        public void PrintAnimals()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("Зоопарк пуст");
                return;
            }
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i}. {animals[i].Name}, {animals[i].GetType().Name}");
            }
        }
        public void FeedAnimal(int index)
        {
            if (index < 0 || index >= animals.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Неверный индекс животного");
            }
            animals[index].Eat();
        }
    }
}
