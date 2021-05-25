using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class GrupoIngrediente
    {
        public GrupoIngrediente()
        {
            RecetaIngredientes = new HashSet<RecetaIngrediente>();
        }

        [Key]
        public int GrupoIngredienteId { get; set; }
        [Required]
        [StringLength(50)]
        public string Grupo { get; set; }
        public short Posicion { get; set; }
        public bool EsBase { get; set; }
        public bool EsOpcional { get; set; }
        public bool EsExtra { get; set; }
        public bool ConsumoLocal { get; set; }
        public bool Empaque { get; set; }

        [InverseProperty(nameof(RecetaIngrediente.GrupoIngrediente))]
        public virtual ICollection<RecetaIngrediente> RecetaIngredientes { get; set; }
    }
}
