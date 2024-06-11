namespace NetRom.Weather.Core.Entities;

public class City : Entity
{
    public string Name { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
