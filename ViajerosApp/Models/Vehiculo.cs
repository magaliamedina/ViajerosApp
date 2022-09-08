namespace ViajerosApp.Models
{
    public class Vehiculo
    {
        public int ID { get; set; }
        public int TipoVehiculoID { get; set; }
        public TipoVehiculo TipoVehiculo { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
    }
}
