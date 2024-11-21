using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DB.Models;

namespace DB.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VentaId { get; set; }
        public int Factura { get; set; }
        public DateOnly fecha { get; set; }
        public decimal Total { get; set; }
        //relaciones
        public int ClienteId { get; set; }
        public virtual ICollection<DetalleVenta>? Detalle { get; set; }

    }
}

