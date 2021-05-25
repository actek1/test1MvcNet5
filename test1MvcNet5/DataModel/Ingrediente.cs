using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    [Index(nameof(Ingrediente1), Name = "IX_Ingredientes", IsUnique = true)]
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            IngredienteVariantes = new HashSet<IngredienteVariante>();
            PlatilloIngredienteVariantes = new HashSet<PlatilloIngredienteVariante>();
            RecetaIngredientes = new HashSet<RecetaIngrediente>();
        }

        [Key]
        public int IngredienteId { get; set; }
        [Required]
        [Column("Ingrediente")]
        [StringLength(50)]
        public string Ingrediente1 { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string UnidadMedida { get; set; }
        [Required]
        [StringLength(50)]
        public string TipoIngrediente { get; set; }
        public bool Refrigeracion { get; set; }
        public byte Caducidad { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        [InverseProperty(nameof(IngredienteVariante.Ingrediente))]
        public virtual ICollection<IngredienteVariante> IngredienteVariantes { get; set; }
        [InverseProperty(nameof(PlatilloIngredienteVariante.Ingrediente))]
        public virtual ICollection<PlatilloIngredienteVariante> PlatilloIngredienteVariantes { get; set; }
        [InverseProperty(nameof(RecetaIngrediente.Ingrediente))]
        public virtual ICollection<RecetaIngrediente> RecetaIngredientes { get; set; }
    }
}
