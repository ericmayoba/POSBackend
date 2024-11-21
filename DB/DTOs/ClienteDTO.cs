using DB.Models;
using Newtonsoft.Json;

namespace DB.DTOs
{
    public class ClienteDTO
    {
        public int ClienteID { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        [JsonIgnore]
        public virtual ICollection<Venta>? Ventas { get; set; }
    }
}



