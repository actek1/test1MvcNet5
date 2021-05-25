using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace test1MvcNet5.DataModel
{
    [Index(nameof(Name), Name = "RoleNameIndex", IsUnique = true)]
    public partial class Role
    {
        public Role()
        {
            UsuarioRoles = new HashSet<UsuarioRole>();
        }

        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [InverseProperty(nameof(UsuarioRole.Role))]
        public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; }
    }
}
