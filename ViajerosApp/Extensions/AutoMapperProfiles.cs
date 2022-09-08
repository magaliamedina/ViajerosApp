using AutoMapper;
using ViajerosApp.DTO;
using ViajerosApp.Models;

namespace ViajerosApp.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CiudadDTO, Ciudad>();
            CreateMap<Ciudad, CiudadDTO>();

            CreateMap<VehiculoDTO, Vehiculo>();
            CreateMap<Vehiculo, VehiculoDTO>();

            CreateMap<ViajeDTO, Viaje>();
            CreateMap<Viaje, ViajeDTO>();

            CreateMap<ViajeroDTO, Viajero>();
            CreateMap<Viajero, ViajeroDTO>();
        }
    }
}
