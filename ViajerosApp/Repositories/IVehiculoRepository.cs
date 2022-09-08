using ViajerosApp.Models;

namespace ViajerosApp.Repositories
{
    public interface IVehiculoRepository
    {
        public void Add(Vehiculo vehiculo);
        public bool Delete(int id);
        public Vehiculo Update(Vehiculo vehiculo);
        public List<Vehiculo> GetAll();
        public Vehiculo GetById(int Id);

    }
}
