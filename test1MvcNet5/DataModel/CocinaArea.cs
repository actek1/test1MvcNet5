using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class CocinaArea
    {
        public CocinaArea()
        {
            RecetaCocinaAreas = new HashSet<RecetaCocinaArea>();
        }

        [Key]
        public int CocinaAreaId { get; set; }
        [Required]
        [Column("CocinaArea")]
        [StringLength(50)]
        public string CocinaArea1 { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }
        [Column("ImpresoraIP")]
        [StringLength(15)]
        public string ImpresoraIp { get; set; }
        [Required]
        [StringLength(5)]
        public string HorarioInicio { get; set; }
        [Required]
        [StringLength(5)]
        public string HorarioCierre { get; set; }

        [InverseProperty(nameof(RecetaCocinaArea.CocinaArea))]
        public virtual ICollection<RecetaCocinaArea> RecetaCocinaAreas { get; set; }
    }
}
