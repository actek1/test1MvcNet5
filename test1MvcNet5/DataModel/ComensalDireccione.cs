using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class ComensalDireccione
    {
        [Key]
        public int ComensalDireccionId { get; set; }
        public int ComensalId { get; set; }
        [Required]
        [StringLength(50)]
        public string Calle { get; set; }
        [Required]
        [StringLength(10)]
        public string NumeroExterior { get; set; }
        [StringLength(10)]
        public string NumeroInterior { get; set; }
        [Required]
        [StringLength(50)]
        public string Colonia { get; set; }
        [Required]
        [StringLength(50)]
        public string Poblacion { get; set; }
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }
        [Required]
        [Column("CP")]
        [StringLength(5)]
        public string Cp { get; set; }
        [StringLength(100)]
        public string EntreCalles { get; set; }
        [StringLength(10)]
        public string Referencia { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Latitud { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Longitud { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal DistanciaRestaurante { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(ComensalId))]
        [InverseProperty(nameof(Comensale.ComensalDirecciones))]
        public virtual Comensale Comensal { get; set; }
    }
}
