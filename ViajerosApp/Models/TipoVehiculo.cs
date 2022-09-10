using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViajerosApp.Models
{
    public class TipoVehiculo
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}
