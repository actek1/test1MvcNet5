using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class PlatilloEleccione
    {
        [Key]
        public int ComandaId { get; set; }
        [Key]
        public int PlatilloId { get; set; }
        [Key]
        public int IngredienteId { get; set; }
        [Key]
        public int GrupoIngredienteId { get; set; }
        [Key]
        public int ComandaPlatilloId { get; set; }
        public int? IngredienteVarianteId { get; set; }
        [Column(TypeName = "money")]
        public decimal PrecioIngrediente { get; set; }

        [ForeignKey(nameof(ComandaPlatilloId))]
        [InverseProperty("PlatilloElecciones")]
        public virtual ComandaPlatillo ComandaPlatillo { get; set; }
        [ForeignKey(nameof(IngredienteVarianteId))]
        [InverseProperty("PlatilloElecciones")]
        public virtual IngredienteVariante IngredienteVariante { get; set; }
        [ForeignKey(nameof(PlatilloId))]
        [InverseProperty(nameof(Receta.PlatilloElecciones))]
        public virtual Receta Platillo { get; set; }
        [ForeignKey("PlatilloId,IngredienteId,GrupoIngredienteId")]
        [InverseProperty("PlatilloElecciones")]
        public virtual RecetaIngrediente RecetaIngrediente { get; set; }
    }
}
