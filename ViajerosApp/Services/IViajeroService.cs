using ViajerosApp.DTO;

namespace ViajerosApp.Services
{
    public interface IViajeroService
    {
        public IEnumerable<ViajeroDTO> GetAll();
        void Add(ViajeroDTO viajeroDTO);
    }
}
