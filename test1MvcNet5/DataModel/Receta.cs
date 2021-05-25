using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    [Index(nameof(Receta1), Name = "IX_Recetas", IsUnique = true)]
    public partial class Receta
    {
        public Receta()
        {
            ComandaPlatillos = new HashSet<ComandaPlatillo>();
            PlatilloElecciones = new HashSet<PlatilloEleccione>();
            PlatilloIngredienteVariantes = new HashSet<PlatilloIngredienteVariante>();
            PlatilloPrecios = new HashSet<PlatilloPrecio>();
            RecetaCocinaAreas = new HashSet<RecetaCocinaArea>();
            RecetaIngredientes = new HashSet<RecetaIngrediente>();
        }

        [Key]
        public int RecetaId { get; set; }
        public int? CategoriaId { get; set; }
        [Required]
        [Column("Receta")]
        [StringLength(50)]
        public string Receta1 { get; set; }
        public byte? TiempoPreparacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaRegistro { get; set; }
        public bool Activo { get; set; }
        [StringLength(50)]
        public string TipoReceta { get; set; }
        public int? Propiedades { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        [InverseProperty(nameof(Menu.Receta))]
        public virtual Menu Categoria { get; set; }
        [InverseProperty(nameof(ComandaPlatillo.Platillo))]
        public virtual ICollection<ComandaPlatillo> ComandaPlatillos { get; set; }
        [InverseProperty(nameof(PlatilloEleccione.Platillo))]
        public virtual ICollection<PlatilloEleccione> PlatilloElecciones { get; set; }
        [InverseProperty(nameof(PlatilloIngredienteVariante.Platillo))]
        public virtual ICollection<PlatilloIngredienteVariante> PlatilloIngredienteVariantes { get; set; }
        [InverseProperty(nameof(PlatilloPrecio.Platillo))]
        public virtual ICollection<PlatilloPrecio> PlatilloPrecios { get; set; }
        [InverseProperty(nameof(RecetaCocinaArea.Receta))]
        public virtual ICollection<RecetaCocinaArea> RecetaCocinaAreas { get; set; }
        [InverseProperty(nameof(RecetaIngrediente.Receta))]
        public virtual ICollection<RecetaIngrediente> RecetaIngredientes { get; set; }
    }
}
