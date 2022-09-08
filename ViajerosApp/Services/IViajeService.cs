using ViajerosApp.DTO;
using ViajerosApp.Models;

namespace ViajerosApp.Services
{
    public interface IViajeService
    {
        public IEnumerable<ViajeDTO> GetAll();
        void Add(ViajeDTO viajeDTO);
        public Viaje Edit(int Id, ViajeDTO viajeDTO);
        public bool Delete(int id);
        public List<Viaje> GetByFecha(DateTime fecha);
        public List<Viaje> GetByCiudadDestinoID(int ciudadID);
        public List<Viaje> GetByVehiculoID(int vehiculoID);


    }
}
