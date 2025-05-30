namespace ZooApi.Data.Entities
{
    public class AnimalEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int EnergyLevel { get; set; }
    }
}
