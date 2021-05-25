using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            UsuarioCuenta = new HashSet<UsuarioCuenta>();
        }

        [Key]
        public int CuentaId { get; set; }
        [Required]
        [Column("Cuenta")]
        [StringLength(50)]
        public string Cuenta1 { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }

        [InverseProperty("Cuenta")]
        public virtual ICollection<UsuarioCuenta> UsuarioCuenta { get; set; }
    }
}
