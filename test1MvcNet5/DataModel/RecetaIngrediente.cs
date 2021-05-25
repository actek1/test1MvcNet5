using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class RecetaIngrediente
    {
        public RecetaIngrediente()
        {
            IngredientePrecios = new HashSet<IngredientePrecio>();
            PlatilloElecciones = new HashSet<PlatilloEleccione>();
        }

        [Key]
        public int RecetaId { get; set; }
        [Key]
        public int IngredienteId { get; set; }
        [Key]
        public int GrupoIngredienteId { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Cantidad { get; set; }
        [StringLength(50)]
        public string Subgrupo { get; set; }

        [ForeignKey(nameof(GrupoIngredienteId))]
        [InverseProperty("RecetaIngredientes")]
        public virtual GrupoIngrediente GrupoIngrediente { get; set; }
        [ForeignKey(nameof(IngredienteId))]
        [InverseProperty("RecetaIngredientes")]
        public virtual Ingrediente Ingrediente { get; set; }
        [ForeignKey(nameof(RecetaId))]
        [InverseProperty("RecetaIngredientes")]
        public virtual Receta Receta { get; set; }
        [InverseProperty(nameof(IngredientePrecio.RecetaIngrediente))]
        public virtual ICollection<IngredientePrecio> IngredientePrecios { get; set; }
        [InverseProperty(nameof(PlatilloEleccione.RecetaIngrediente))]
        public virtual ICollection<PlatilloEleccione> PlatilloElecciones { get; set; }
    }
}
