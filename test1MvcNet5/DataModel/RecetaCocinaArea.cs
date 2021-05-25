using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class RecetaCocinaArea
    {
        [Key]
        public int RecetaId { get; set; }
        [Key]
        public int CocinaAreaId { get; set; }

        [ForeignKey(nameof(CocinaAreaId))]
        [InverseProperty("RecetaCocinaAreas")]
        public virtual CocinaArea CocinaArea { get; set; }
        [ForeignKey(nameof(RecetaId))]
        [InverseProperty("RecetaCocinaAreas")]
        public virtual Receta Receta { get; set; }
    }
}
