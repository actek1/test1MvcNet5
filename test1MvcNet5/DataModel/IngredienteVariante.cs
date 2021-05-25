using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class IngredienteVariante
    {
        public IngredienteVariante()
        {
            PlatilloElecciones = new HashSet<PlatilloEleccione>();
            PlatilloIngredienteVariantes = new HashSet<PlatilloIngredienteVariante>();
        }

        [Key]
        public int IngredienteVarianteId { get; set; }
        public int IngredienteId { get; set; }
        [Required]
        [StringLength(50)]
        public string Variante { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        [ForeignKey(nameof(IngredienteId))]
        [InverseProperty("IngredienteVariantes")]
        public virtual Ingrediente Ingrediente { get; set; }
        [InverseProperty(nameof(PlatilloEleccione.IngredienteVariante))]
        public virtual ICollection<PlatilloEleccione> PlatilloElecciones { get; set; }
        [InverseProperty(nameof(PlatilloIngredienteVariante.IngredienteVariante))]
        public virtual ICollection<PlatilloIngredienteVariante> PlatilloIngredienteVariantes { get; set; }
    }
}
