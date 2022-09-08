using ViajerosApp.Data;
using ViajerosApp.Models;

namespace ViajerosApp.Repositories
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly ViajerosDbContext _context;

        public CiudadRepository(ViajerosDbContext context)
        {
            _context = context;
        }

        public void Add(Ciudad ciudad)
        {
            if (ciudad != null)
            {
                try
                {
                    _context.Ciudades.Add(ciudad);
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
            var ciudad = _context.Ciudades.Find(id);
            if (ciudad != null)
            {
                try
                {
                    _context.Ciudades.Remove(ciudad);
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

        public List<Ciudad> GetAll()
        {
            return _context.Ciudades.ToList();
        }

        public Ciudad GetById(int Id)
        {
            return _context.Ciudades.Find(Id);
        }

        public Ciudad Update(Ciudad ciudad)
        {
            try
            {
                _context.Update(ciudad);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ciudad;
        }
    }
}
