using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class PlatilloPrecio
    {
        [Key]
        public int PlatilloId { get; set; }
        [Key]
        public int OrigenComandaId { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }

        [ForeignKey(nameof(OrigenComandaId))]
        [InverseProperty("PlatilloPrecios")]
        public virtual OrigenComanda OrigenComanda { get; set; }
        [ForeignKey(nameof(PlatilloId))]
        [InverseProperty(nameof(Receta.PlatilloPrecios))]
        public virtual Receta Platillo { get; set; }
    }
}
