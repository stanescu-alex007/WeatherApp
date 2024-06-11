using AutoMapper;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Core.Entities;

namespace NetRom.Weather.Application.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CityModelForCreation, City>().ReverseMap();
        CreateMap<City, CityModel>().ReverseMap();
    }
}
