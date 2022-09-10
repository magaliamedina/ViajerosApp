using System.ComponentModel.DataAnnotations;
using ViajerosApp.Models;

namespace ViajerosApp.DTO
{
    public class ViajeDTO
    {
        public int ViajeroID { get; set; }
        public Viajero Viajero { get; set; }

        public Ciudad Ciudad { get; set; }

        public int CiudadID { get; set; } //ciudad de destino
        public int VehiculoID { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public DateTime Fecha { get; set; }
        [Range(0, 10)]
        public int CantidadDias { get; set; }
    }
}
