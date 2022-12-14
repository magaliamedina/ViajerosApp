using AutoMapper;
using ViajerosApp.DTO;
using ViajerosApp.Models;
using ViajerosApp.Repositories;

namespace ViajerosApp.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _viajeRepository;
        private readonly IMapper _mapper;

        public ViajeService(IViajeRepository viajeRepository, IMapper mapper)
        {
            _viajeRepository = viajeRepository;
            _mapper = mapper;
        }

        public void Add(ViajeDTO viajeDTO)
        {
            try
            {
                Viaje viaje = new Viaje()
                {
                    Viajero = viajeDTO.Viajero,
                    CiudadID = viajeDTO.CiudadID,
                    Vehiculo = viajeDTO.Vehiculo,
                    Fecha= viajeDTO.Fecha,
                    CantidadDias= viajeDTO.CantidadDias              
                };
                _viajeRepository.Add(viaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _viajeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Viaje Edit(int Id, ViajeDTO viajeDTO)
        {
            var viajeAnterior = _viajeRepository.GetById(Id);
            if (viajeAnterior != null)
            {
                viajeAnterior.Viajero = viajeDTO.Viajero;
                viajeAnterior.CiudadID = viajeDTO.CiudadID;
                viajeAnterior.Vehiculo = viajeDTO.Vehiculo;
                viajeAnterior.Fecha = viajeDTO.Fecha;
                viajeAnterior.CantidadDias = viajeDTO.CantidadDias;
                try
                {
                    return _viajeRepository.Update(viajeAnterior);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public IEnumerable<ListViajeDTO> GetAll()
        {
            var viaje = _viajeRepository.GetAll();
            return _mapper.Map<IEnumerable<ListViajeDTO>>(viaje);
        }

        public List<Viaje> GetByCiudadDestinoID(int ciudadID)
        {
            return _viajeRepository.GetAll().Where(v => v.CiudadID == ciudadID).ToList();
        }

        public List<Viaje> GetByFecha(DateTime fecha)
        {
            return _viajeRepository.GetAll().Where(v => v.Fecha == fecha).ToList();
        }

        public List<Viaje> GetByVehiculoID(int vehiculoID)
        {
            return _viajeRepository.GetAll().Where(v => v.VehiculoID == vehiculoID).ToList();
        }
    }
}
