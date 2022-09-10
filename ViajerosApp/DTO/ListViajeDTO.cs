using ViajerosApp.Models;

namespace ViajerosApp.DTO
{
    public class ListViajeDTO
    {
       public int ViajeroID { get; set; }
        public Viajero Viajero { get; set; }
        public int CiudadID { get; set; } //ciudad de destino
        public Ciudad Ciudad { get; set; }
        public int VehiculoID { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public DateTime Fecha { get; set; }

        public int CantidadDias { get; set; }
        public bool? Reprogramado { get; set; }
    }
}
