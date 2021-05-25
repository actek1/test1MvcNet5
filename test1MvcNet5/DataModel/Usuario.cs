using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    [Index(nameof(UserName), Name = "UserNameIndex", IsUnique = true)]
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioCuenta = new HashSet<UsuarioCuenta>();
            UsuarioDatos = new HashSet<UsuarioDato>();
            UsuarioLogins = new HashSet<UsuarioLogin>();
            UsuarioRoles = new HashSet<UsuarioRole>();
        }

        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UsuarioCuenta> UsuarioCuenta { get; set; }
        [InverseProperty(nameof(UsuarioDato.User))]
        public virtual ICollection<UsuarioDato> UsuarioDatos { get; set; }
        [InverseProperty(nameof(UsuarioLogin.User))]
        public virtual ICollection<UsuarioLogin> UsuarioLogins { get; set; }
        [InverseProperty(nameof(UsuarioRole.User))]
        public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; }
    }
}
