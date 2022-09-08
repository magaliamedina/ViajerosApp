using ViajerosApp.DTO;
using ViajerosApp.Models;

namespace ViajerosApp.Services
{
    public interface ICiudadService
    {
        public IEnumerable<CiudadDTO> GetAll();
        void Add(CiudadDTO ciudad);
        public Ciudad Edit(int Id, CiudadDTO ciudad);
        public bool Delete(int id);
    }
}
