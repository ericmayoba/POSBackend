using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DB.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        //clave foranea
        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }

    }
}

