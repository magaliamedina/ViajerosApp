namespace ViajerosApp.DTO
{
    public class ViajeroDTO
    {
        public int ID { get; set; }
        public string NombreYApellido { get; set; }
        public int? CiudadID { get; set; } //ciudad de origen
    }
}
