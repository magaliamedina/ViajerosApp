using Microsoft.EntityFrameworkCore;
using ViajerosApp.Data;
using ViajerosApp.Models;

namespace ViajerosApp.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ViajerosDbContext _context;

        public VehiculoRepository(ViajerosDbContext context)
        {
            _context = context;
        }

        public void Add(Vehiculo vehiculo)
        {
            if (vehiculo != null)
            {
                try
                {
                    _context.Vehiculos.Add(vehiculo);
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
            var vehiculo = _context.Vehiculos.Find(id);
            if (vehiculo != null)
            {
                try
                {
                    _context.Vehiculos.Remove(vehiculo);
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

        public List<Vehiculo> GetAll()
        {
            return _context.Vehiculos.Include(v => v.TipoVehiculo).ToList();
        }

        public Vehiculo GetById(int Id)
        {
            return _context.Vehiculos.Find(Id);
        }

        public Vehiculo Update(Vehiculo vehiculoModificado)
        {
            try
            {
                _context.Update(vehiculoModificado);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vehiculoModificado;
        }
    }
}
