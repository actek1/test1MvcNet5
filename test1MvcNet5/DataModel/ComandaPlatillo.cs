using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class ComandaPlatillo
    {
        public ComandaPlatillo()
        {
            PlatilloElecciones = new HashSet<PlatilloEleccione>();
        }

        [Key]
        public int ComandaPlatilloId { get; set; }
        public int ComandaId { get; set; }
        public int PlatilloId { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "money")]
        public decimal PrecioPlatillo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaOrden { get; set; }
        public short? Comensal { get; set; }
        public byte OrdenServicio { get; set; }
        [StringLength(200)]
        public string Notas { get; set; }

        [ForeignKey(nameof(PlatilloId))]
        [InverseProperty(nameof(Receta.ComandaPlatillos))]
        public virtual Receta Platillo { get; set; }
        [InverseProperty(nameof(PlatilloEleccione.ComandaPlatillo))]
        public virtual ICollection<PlatilloEleccione> PlatilloElecciones { get; set; }
    }
}
