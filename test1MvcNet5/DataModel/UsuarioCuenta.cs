using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class UsuarioCuenta
    {
        [Key]
        [StringLength(128)]
        public string UserId { get; set; }
        [Key]
        public int CuentaId { get; set; }

        [ForeignKey(nameof(CuentaId))]
        [InverseProperty("UsuarioCuenta")]
        public virtual Cuenta Cuenta { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Usuario.UsuarioCuenta))]
        public virtual Usuario User { get; set; }
    }
}
