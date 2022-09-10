using AutoMapper;
using ViajerosApp.DTO;
using ViajerosApp.Models;
using ViajerosApp.Repositories;

namespace ViajerosApp.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IMapper _mapper;

        public VehiculoService(IVehiculoRepository vehiculoRepository, IMapper mapper)
        {
            _vehiculoRepository = vehiculoRepository;
            _mapper = mapper;
        }

        public void Add(VehiculoDTO vehiculoDTO)
        {
            try
            {
                Vehiculo vehiculo = new Vehiculo()
                {
                    TipoVehiculoID = vehiculoDTO.TipoVehiculoID,
                    Patente = vehiculoDTO.Patente,
                    Marca = vehiculoDTO.Marca,
                };
                _vehiculoRepository.Add(vehiculo);
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
                return _vehiculoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vehiculo Edit(int Id, VehiculoDTO vehiculo)
        {
            var vehiculoAnterior = _vehiculoRepository.GetById(Id);
            if (vehiculoAnterior != null)
            {
                vehiculoAnterior.Patente = vehiculo.Patente;
                vehiculoAnterior.Marca = vehiculo.Patente;
                try
                {
                    return _vehiculoRepository.Update(vehiculoAnterior);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            var vehiculos = _vehiculoRepository.GetAll();
            //var vehiculoReturn =_mapper.Map<IEnumerable<VehiculoDTO>>(vehiculos);
            // return vehiculoReturn;
            return vehiculos;
        }
    }
}
