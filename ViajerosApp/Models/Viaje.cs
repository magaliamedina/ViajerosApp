using System.ComponentModel.DataAnnotations;

namespace ViajerosApp.Models
{
    public class Viaje
    {
        public int ID { get; set; }
        public int ViajeroID { get; set; }
        public Viajero Viajero { get; set; }
        public int CiudadID { get; set; } //ciudad de destino
        public Ciudad Ciudad { get; set; }
        public int VehiculoID { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public DateTime Fecha { get; set; }

        [Range(0,10)]
        public int CantidadDias { get; set; }
        public bool? Reprogramado { get; set; }
    }
}
