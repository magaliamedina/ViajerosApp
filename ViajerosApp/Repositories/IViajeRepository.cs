using ViajerosApp.Models;

namespace ViajerosApp.Repositories
{
    public interface IViajeRepository
    {
        public void Add(Viaje viaje);
        public bool Delete(int id);
        public Viaje Update(Viaje viaje);
        public List<Viaje> GetAll();
        public Viaje GetById(int id); 
    }
}
