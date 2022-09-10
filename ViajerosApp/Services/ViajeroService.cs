using AutoMapper;
using ViajerosApp.DTO;
using ViajerosApp.Models;
using ViajerosApp.Repositories;

namespace ViajerosApp.Services
{
    public class ViajeroService : IViajeroService
    {
        private readonly IViajeroRepository _viajeroRepository;
        private readonly IMapper _mapper;

        public ViajeroService(IViajeroRepository viajeroRepository, IMapper mapper)
        {
            _viajeroRepository = viajeroRepository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public void Add(ViajeroDTO viajeroDTO)
        {
            try
            {
                Viajero viajero = new Viajero()
                {
                    NombreYApellido = viajeroDTO.NombreYApellido
                };
                _viajeroRepository.Add(viajero);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ViajeroDTO> GetAll()
        {
            var viajero = _viajeroRepository.GetAll();
            return _mapper.Map<IEnumerable<ViajeroDTO>>(viajero);
        }
    }
}
