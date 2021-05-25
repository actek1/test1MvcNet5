using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class CajaSesione
    {
        public CajaSesione()
        {
            CajaTransacciones = new HashSet<CajaTransaccione>();
        }

        [Key]
        public int CajaSesionId { get; set; }
        public int CajaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaApertura { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaCierre { get; set; }
        [Column(TypeName = "money")]
        public decimal EfectivoFondo { get; set; }
        [Column(TypeName = "money")]
        public decimal? EfectivoCierre { get; set; }

        [InverseProperty(nameof(CajaTransaccione.CajaSesion))]
        public virtual ICollection<CajaTransaccione> CajaTransacciones { get; set; }
    }
}
