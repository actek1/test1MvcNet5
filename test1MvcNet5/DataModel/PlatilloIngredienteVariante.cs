using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class PlatilloIngredienteVariante
    {
        [Key]
        public int PlatilloId { get; set; }
        [Key]
        public int IngredienteId { get; set; }
        [Key]
        public int IngredienteVarianteId { get; set; }
        [Required]
        [StringLength(10)]
        public string Comportamiento { get; set; }

        [ForeignKey(nameof(IngredienteId))]
        [InverseProperty("PlatilloIngredienteVariantes")]
        public virtual Ingrediente Ingrediente { get; set; }
        [ForeignKey(nameof(IngredienteVarianteId))]
        [InverseProperty("PlatilloIngredienteVariantes")]
        public virtual IngredienteVariante IngredienteVariante { get; set; }
        [ForeignKey(nameof(PlatilloId))]
        [InverseProperty(nameof(Receta.PlatilloIngredienteVariantes))]
        public virtual Receta Platillo { get; set; }
    }
}
