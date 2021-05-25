using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class Comensale
    {
        public Comensale()
        {
            ComensalDirecciones = new HashSet<ComensalDireccione>();
        }

        [Key]
        public int ComensalId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string ApellidoPaterno { get; set; }
        [StringLength(50)]
        public string ApellidoMaterno { get; set; }
        [StringLength(1)]
        public string Sexo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaNacimiento { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(12)]
        public string Telefono { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty(nameof(ComensalDireccione.Comensal))]
        public virtual ICollection<ComensalDireccione> ComensalDirecciones { get; set; }
    }
}
