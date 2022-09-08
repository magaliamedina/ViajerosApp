using ViajerosApp.DTO;
using ViajerosApp.Models;

namespace ViajerosApp.Services
{
    public interface IVehiculoService
    {
        public IEnumerable<VehiculoDTO> GetAll(); 
        void Add(VehiculoDTO vehiculo); 
        public Vehiculo Edit(int Id, VehiculoDTO vehiculo); 
        public bool Delete(int id);
    }
}
