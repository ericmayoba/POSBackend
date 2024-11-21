using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DB.Models
{
	public class Cliente
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ClienteID { get; set; }
		public string? Nombres { get; set; }
		public string? Apellidos { get; set; }
		public string? Direccion { get; set; }
		public string? Telefono { get; set; }

		[JsonIgnore]
		public virtual ICollection<Venta>? Ventas { get; set; }
	}
}






