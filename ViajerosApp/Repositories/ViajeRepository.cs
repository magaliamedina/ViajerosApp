using Microsoft.EntityFrameworkCore;
using ViajerosApp.Data;
using ViajerosApp.Models;

namespace ViajerosApp.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly ViajerosDbContext _context;

        public ViajeRepository(ViajerosDbContext context)
        {
            _context = context;
        }

        public void Add(Viaje viaje)
        {
            if (viaje != null)
            {
                try
                {
                    _context.Viajes.Add(viaje);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public bool Delete(int id)
        {
            var viaje = _context.Viajes.Find(id);
            if (viaje != null)
            {
                try
                {
                    _context.Viajes.Remove(viaje);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return true;
            }
            return false;
        }

        public List<Viaje> GetAll()
        {
            return _context.Viajes
                .Include(v => v.Viajero)
                .Include(v => v.Ciudad)
                .Include(v => v.Vehiculo)
                .ToList();
        }

        public Viaje GetById(int id)
        {
            return _context.Viajes.Find(id);
        }

        public Viaje Update(Viaje viajeModificado)
        {
            try
            {
                _context.Update(viajeModificado);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viajeModificado;
        }
    }
}
