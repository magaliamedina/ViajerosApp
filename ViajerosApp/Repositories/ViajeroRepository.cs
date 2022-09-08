using Microsoft.EntityFrameworkCore;
using ViajerosApp.Data;
using ViajerosApp.Models;

namespace ViajerosApp.Repositories
{
    public class ViajeroRepository : IViajeroRepository
    {
        private readonly ViajerosDbContext _context;

        public ViajeroRepository(ViajerosDbContext context)
        {
            _context = context;
        }

        public void Add(Viajero viajero)
        {
            if (viajero != null)
            {
                try
                {
                    _context.Viajeros.Add(viajero);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public List<Viajero> GetAll()
        {
            return _context.Viajeros.Include(v => v.Ciudad).ToList();
        }
    }
}
