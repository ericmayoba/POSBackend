using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DB.Models
{
    public class DetalleVenta
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetalleVentaId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        //relaciones
        public int ProductoId { get; set; }
        public int VentaId { get; set; }
        public virtual Producto? Producto { get; set; }

        [JsonIgnore]
        public virtual Venta? Venta { get; set; }

    }
    }

