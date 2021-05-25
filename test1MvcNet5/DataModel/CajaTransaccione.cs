using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class CajaTransaccione
    {
        [Key]
        public int CajaTransaccionId { get; set; }
        public int CajaSesionId { get; set; }
        public bool TipoTransaccion { get; set; }
        [Required]
        [StringLength(1)]
        public string Transaccion { get; set; }
        [Required]
        [StringLength(1)]
        public string Instrumento { get; set; }
        [Required]
        [StringLength(10)]
        public string Datos { get; set; }
        [Column(TypeName = "money")]
        public decimal Importe { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        public int? ComandaId { get; set; }
        public int? AutorizadorId { get; set; }

        [ForeignKey(nameof(CajaSesionId))]
        [InverseProperty(nameof(CajaSesione.CajaTransacciones))]
        public virtual CajaSesione CajaSesion { get; set; }
    }
}
