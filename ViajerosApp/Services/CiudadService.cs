using AutoMapper;
using ViajerosApp.DTO;
using ViajerosApp.Models;
using ViajerosApp.Repositories;

namespace ViajerosApp.Services
{
    public class CiudadService : ICiudadService
    {

        private readonly ICiudadRepository _ciudadRepository;
        private readonly IMapper _mapper;

        public CiudadService(ICiudadRepository ciudadRepository, IMapper mapper)
        {
            _ciudadRepository = ciudadRepository;
            _mapper = mapper;
        }

        public void Add(CiudadDTO ciudadDTO)
        {
            try
            {
                Ciudad ciudad = new Ciudad()
                {
                    Nombre = ciudadDTO.Nombre
                };
                _ciudadRepository.Add(ciudad);
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
                return _ciudadRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ciudad Edit(int Id, CiudadDTO ciudadDTO)
        {
            var ciudadAnterior = _ciudadRepository.GetById(Id);
            if (ciudadAnterior != null)
            {
                ciudadAnterior.Nombre = ciudadDTO.Nombre;
                try
                {
                    return _ciudadRepository.Update(ciudadAnterior);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public IEnumerable<CiudadDTO> GetAll()
        {
            var ciudad = _ciudadRepository.GetAll();
            return _mapper.Map<IEnumerable<CiudadDTO>>(ciudad);
        }
    }
}
