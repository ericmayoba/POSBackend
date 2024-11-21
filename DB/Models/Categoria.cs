using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DB.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
        public string? Descripcion { get; set; }
        [JsonIgnore]
        public ICollection<Producto>? Productos { get; set; }
    }
}