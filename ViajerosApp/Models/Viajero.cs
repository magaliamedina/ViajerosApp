using System.ComponentModel.DataAnnotations;

namespace ViajerosApp.Models
{
    public class Viajero
    {
        public int ID { get; set; }
        public string NombreYApellido { get; set; }

        public int? CiudadID { get; set; } //ciudad de origen
        public Ciudad? Ciudad { get; set; }
    }
}
