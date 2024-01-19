namespace Domain.Models.Engines
{
    public class Engine
    {
        public Guid EngineId { get; set; }
        public required string EngineName { get; set; }
        public required string EngineFuel { get; set; }
        public required int HorsePower { get; set; }
    }
}