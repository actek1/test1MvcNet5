using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class OrigenComanda
    {
        public OrigenComanda()
        {
            IngredientePrecios = new HashSet<IngredientePrecio>();
            PlatilloPrecios = new HashSet<PlatilloPrecio>();
        }

        [Key]
        public int OrigenComandaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Origen { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public bool Restaurante { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? ExternoComision { get; set; }
        public bool Recoleccion { get; set; }
        [StringLength(1)]
        public string RepartoTipo { get; set; }
        public bool CobroRestaurante { get; set; }
        public bool CobroEfectivo { get; set; }
        [Column("CobroTDD")]
        public bool CobroTdd { get; set; }
        [Column("CobroTDC")]
        public bool CobroTdc { get; set; }
        public bool CobroTransferencia { get; set; }

        [InverseProperty(nameof(IngredientePrecio.OrigenComanda))]
        public virtual ICollection<IngredientePrecio> IngredientePrecios { get; set; }
        [InverseProperty(nameof(PlatilloPrecio.OrigenComanda))]
        public virtual ICollection<PlatilloPrecio> PlatilloPrecios { get; set; }
    }
}
