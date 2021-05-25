using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class IngredientePrecio
    {
        [Key]
        public int PlatilloId { get; set; }
        [Key]
        public int IngredienteId { get; set; }
        [Key]
        public int GrupoIngredienteId { get; set; }
        [Key]
        public int OrigenComandaId { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }
        public string Otros { get; set; }

        [ForeignKey(nameof(OrigenComandaId))]
        [InverseProperty("IngredientePrecios")]
        public virtual OrigenComanda OrigenComanda { get; set; }
        [ForeignKey("PlatilloId,IngredienteId,GrupoIngredienteId")]
        [InverseProperty("IngredientePrecios")]
        public virtual RecetaIngrediente RecetaIngrediente { get; set; }
    }
}
