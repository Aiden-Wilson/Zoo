namespace ZooApi.Models
{
    abstract class Animal : IAnimal
    {
        protected Animal() 
        {
            Id = Guid.NewGuid();
        }
        protected Animal(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; }
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
        public virtual void Eat(int foodAmount)
        {
            EnergyLevel +=foodAmount;
            if (EnergyLevel > 100)
                EnergyLevel = 100;
        }
        public abstract void MakeSound();
    }
}
