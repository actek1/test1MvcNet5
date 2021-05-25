using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    [Index(nameof(RoleId), Name = "IX_RoleId")]
    [Index(nameof(UserId), Name = "IX_UserId")]
    public partial class UsuarioRole
    {
        [Key]
        [StringLength(128)]
        public string UserId { get; set; }
        [Key]
        [StringLength(128)]
        public string RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("UsuarioRoles")]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Usuario.UsuarioRoles))]
        public virtual Usuario User { get; set; }
    }
}
