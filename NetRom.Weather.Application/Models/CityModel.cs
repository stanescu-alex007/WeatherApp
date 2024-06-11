using System.ComponentModel.DataAnnotations;

namespace NetRom.Weather.Application.Models;

public class CityModel
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public double Longitude { get; set; }

    [Required]
    public double Latitude { get; set; }
    
    public double? Temperature { get; set; }
}
