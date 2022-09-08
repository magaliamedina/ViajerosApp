using System.ComponentModel.DataAnnotations;

namespace ViajerosApp.DTO
{
    public class ViajeDTO
    {
        public int ID { get; set; }
        public int ViajeroID { get; set; }
        public int CiudadID { get; set; } //ciudad de destino
        public int VehiculoID { get; set; }
        public DateTime Fecha { get; set; }
        [Range(0, 10)]
        public int CantidadDias { get; set; }
    }
}
