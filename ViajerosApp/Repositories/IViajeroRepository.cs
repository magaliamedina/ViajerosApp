using ViajerosApp.Models;

namespace ViajerosApp.Repositories
{
    public interface IViajeroRepository
    {
        public void Add(Viajero viajero);
        public List<Viajero> GetAll(); 

    }
}
