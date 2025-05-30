namespace ZooApi.Models
{
    public interface IAnimal
    {
        Guid Id { get; }
        string Name { get; set; }
        int EnergyLevel { get; set; }
        void MakeSound();
        void Eat(int foodAmount);
    }
}
