using ViajerosApp.Models;

namespace ViajerosApp.Repositories
{
    public interface ICiudadRepository
    {
        public void Add(Ciudad ciudad);
        public bool Delete(int id);
        public Ciudad Update(Ciudad ciudad);
        public List<Ciudad> GetAll();
        public Ciudad GetById(int Id);

    }
}
