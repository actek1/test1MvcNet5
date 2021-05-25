using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    [Table("Menu")]
    public partial class Menu
    {
        public Menu()
        {
            Receta = new HashSet<Receta>();
        }

        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Categoria { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public short Posicion { get; set; }

        [InverseProperty("Categoria")]
        public virtual ICollection<Receta> Receta { get; set; }
    }
}
