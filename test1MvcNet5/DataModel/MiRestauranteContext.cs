using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace test1MvcNet5.DataModel
{
    public partial class MiRestauranteContext : DbContext
    {
        public MiRestauranteContext()
        {
        }

        public MiRestauranteContext(DbContextOptions<MiRestauranteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CajaSesione> CajaSesiones { get; set; }
        public virtual DbSet<CajaTransaccione> CajaTransacciones { get; set; }
        public virtual DbSet<CocinaArea> CocinaAreas { get; set; }
        public virtual DbSet<ComandaPlatillo> ComandaPlatillos { get; set; }
        public virtual DbSet<ComensalDireccione> ComensalDirecciones { get; set; }
        public virtual DbSet<Comensale> Comensales { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<GrupoIngrediente> GrupoIngredientes { get; set; }
        public virtual DbSet<Ingrediente> Ingredientes { get; set; }
        public virtual DbSet<IngredientePrecio> IngredientePrecios { get; set; }
        public virtual DbSet<IngredienteVariante> IngredienteVariantes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<OrigenComanda> OrigenComandas { get; set; }
        public virtual DbSet<PlatilloEleccione> PlatilloElecciones { get; set; }
        public virtual DbSet<PlatilloIngredienteVariante> PlatilloIngredienteVariantes { get; set; }
        public virtual DbSet<PlatilloPrecio> PlatilloPrecios { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }
        public virtual DbSet<RecetaCocinaArea> RecetaCocinaAreas { get; set; }
        public virtual DbSet<RecetaIngrediente> RecetaIngredientes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioCuenta> UsuarioCuentas { get; set; }
        public virtual DbSet<UsuarioDato> UsuarioDatos { get; set; }
        public virtual DbSet<UsuarioLogin> UsuarioLogins { get; set; }
        public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MiRestaurante;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CajaSesione>(entity =>
            {
                entity.HasKey(e => e.CajaSesionId)
                    .HasName("PK_SesionesCajas");

                entity.Property(e => e.EfectivoFondo).HasComment("Efectivo con el que abre la caja");
            });

            modelBuilder.Entity<CajaTransaccione>(entity =>
            {
                entity.Property(e => e.AutorizadorId).HasComment("Usuario que autoriza el movimiento");

                entity.Property(e => e.Datos)
                    .IsUnicode(false)
                    .HasComment("Información del pago, como tarjeta, numero de cheque, num de transferencia, etc.");

                entity.Property(e => e.Instrumento)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("TDC, TDD, Efectivo, etc.");

                entity.Property(e => e.TipoTransaccion).HasComment("0 Retiro, |1 Abono");

                entity.Property(e => e.Transaccion)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Definir catalogo");

                entity.HasOne(d => d.CajaSesion)
                    .WithMany(p => p.CajaTransacciones)
                    .HasForeignKey(d => d.CajaSesionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CajaTransacciones_CajaSesiones");
            });

            modelBuilder.Entity<CocinaArea>(entity =>
            {
                entity.Property(e => e.CocinaArea1).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.HorarioCierre).IsUnicode(false);

                entity.Property(e => e.HorarioInicio)
                    .IsUnicode(false)
                    .HasComment("en formato hh:ss");

                entity.Property(e => e.ImpresoraIp).IsUnicode(false);
            });

            modelBuilder.Entity<ComandaPlatillo>(entity =>
            {
                entity.Property(e => e.Comensal).HasComment("El comensal al que se le servirá el plato");

                entity.Property(e => e.Notas).IsUnicode(false);

                entity.Property(e => e.OrdenServicio).HasComment("El orden en el que será servido cada plato a la mesa: primer plato, segundo plato, postre, etc");

                entity.HasOne(d => d.Platillo)
                    .WithMany(p => p.ComandaPlatillos)
                    .HasForeignKey(d => d.PlatilloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComandaPlatillos_Recetas");
            });

            modelBuilder.Entity<ComensalDireccione>(entity =>
            {
                entity.Property(e => e.Calle).IsUnicode(false);

                entity.Property(e => e.Colonia).IsUnicode(false);

                entity.Property(e => e.Cp)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EntreCalles).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.NumeroExterior).IsUnicode(false);

                entity.Property(e => e.NumeroInterior).IsUnicode(false);

                entity.Property(e => e.Poblacion).IsUnicode(false);

                entity.Property(e => e.Referencia).IsUnicode(false);

                entity.HasOne(d => d.Comensal)
                    .WithMany(p => p.ComensalDirecciones)
                    .HasForeignKey(d => d.ComensalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComensalDirecciones_Comensales");
            });

            modelBuilder.Entity<Comensale>(entity =>
            {
                entity.Property(e => e.ApellidoMaterno).IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.Property(e => e.Cuenta1).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<GrupoIngrediente>(entity =>
            {
                entity.Property(e => e.Grupo).IsUnicode(false);
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.Property(e => e.Caducidad).HasComment("Días en los que un ingrediente termina su vida util");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Ingrediente1)
                    .IsUnicode(false)
                    .HasComment("Nombre del ingrediente");

                entity.Property(e => e.Refrigeracion).HasComment("Indica si el ingrediente requiere ser o no refrigerado");

                entity.Property(e => e.TipoIngrediente).IsUnicode(false);

                entity.Property(e => e.UnidadMedida)
                    .IsUnicode(false)
                    .HasComment("Unidad de medida con la que se emplea el ingrediente en la cocina\r\n\r\nDe un catálogo definido: litros, onzas, bolsa, costal, etc.\r\n");
            });

            modelBuilder.Entity<IngredientePrecio>(entity =>
            {
                entity.HasKey(e => new { e.PlatilloId, e.IngredienteId, e.GrupoIngredienteId, e.OrigenComandaId });

                entity.HasOne(d => d.OrigenComanda)
                    .WithMany(p => p.IngredientePrecios)
                    .HasForeignKey(d => d.OrigenComandaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientePrecios_OrigenComandas");

                entity.HasOne(d => d.RecetaIngrediente)
                    .WithMany(p => p.IngredientePrecios)
                    .HasForeignKey(d => new { d.PlatilloId, d.IngredienteId, d.GrupoIngredienteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientePrecios_RecetaIngredientes1");
            });

            modelBuilder.Entity<IngredienteVariante>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Variante).IsUnicode(false);

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.IngredienteVariantes)
                    .HasForeignKey(d => d.IngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredienteVariantes_Ingredientes");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Categoria).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");
            });

            modelBuilder.Entity<OrigenComanda>(entity =>
            {
                entity.HasComment("-Propio (sin costo)\r\n-Externo con costo fijo\r\n-Externo con costo variable");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.ExternoComision).HasComment("El porcentaje de comisión si la venta es externa (formato 999.99)");

                entity.Property(e => e.Origen).IsUnicode(false);

                entity.Property(e => e.RepartoTipo)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("null: sin reparto\r\nA: App de venta y reparto (es variable, y hay comisión implícita)\r\nP: Propio (empleados del restaurante, sin costo)\r\nE: Externo (se paga comisión, como un monto fijo)");

                entity.Property(e => e.Restaurante).HasComment("Define si la comanda proviene directamente del restaurante (true) o si es venta externa (false; por apps por ej)");
            });

            modelBuilder.Entity<PlatilloEleccione>(entity =>
            {
                entity.HasKey(e => new { e.ComandaId, e.PlatilloId, e.IngredienteId, e.GrupoIngredienteId, e.ComandaPlatilloId })
                    .HasName("PK_PlatoElecciones");

                entity.HasOne(d => d.ComandaPlatillo)
                    .WithMany(p => p.PlatilloElecciones)
                    .HasForeignKey(d => d.ComandaPlatilloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatilloElecciones_ComandaPlatillos");

                entity.HasOne(d => d.IngredienteVariante)
                    .WithMany(p => p.PlatilloElecciones)
                    .HasForeignKey(d => d.IngredienteVarianteId)
                    .HasConstraintName("FK_PlatilloElecciones_IngredienteVariantes");

                entity.HasOne(d => d.Platillo)
                    .WithMany(p => p.PlatilloElecciones)
                    .HasForeignKey(d => d.PlatilloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatilloElecciones_Recetas");

                entity.HasOne(d => d.RecetaIngrediente)
                    .WithMany(p => p.PlatilloElecciones)
                    .HasForeignKey(d => new { d.PlatilloId, d.IngredienteId, d.GrupoIngredienteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatilloElecciones_RecetaIngredientes1");
            });

            modelBuilder.Entity<PlatilloIngredienteVariante>(entity =>
            {
                entity.HasKey(e => new { e.PlatilloId, e.IngredienteId, e.IngredienteVarianteId });

                entity.Property(e => e.Comportamiento)
                    .IsUnicode(false)
                    .HasComment("Definirá la acción que se realizará con la variante (IngredienteVarianteId) de un ingrediente dentro de un platillo (RecetaId+IngredienteId). Pueden ser:\r\n-Default: solo se espera una variante por RecetaId+IngredienteId\r\n-Whitelist: elementos que se mostraran explícitamente\r\n-blacklist: elementos que se ocultaran explícitamente");

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.PlatilloIngredienteVariantes)
                    .HasForeignKey(d => d.IngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatilloIngredienteVariantes_Ingredientes");

                entity.HasOne(d => d.IngredienteVariante)
                    .WithMany(p => p.PlatilloIngredienteVariantes)
                    .HasForeignKey(d => d.IngredienteVarianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatilloIngredienteVariantes_IngredienteVariantes");

                entity.HasOne(d => d.Platillo)
                    .WithMany(p => p.PlatilloIngredienteVariantes)
                    .HasForeignKey(d => d.PlatilloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatilloIngredienteVariantes_Recetas");
            });

            modelBuilder.Entity<PlatilloPrecio>(entity =>
            {
                entity.HasKey(e => new { e.PlatilloId, e.OrigenComandaId });

                entity.HasOne(d => d.OrigenComanda)
                    .WithMany(p => p.PlatilloPrecios)
                    .HasForeignKey(d => d.OrigenComandaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatilloPrecios_OrigenComandas");

                entity.HasOne(d => d.Platillo)
                    .WithMany(p => p.PlatilloPrecios)
                    .HasForeignKey(d => d.PlatilloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatilloPrecios_Recetas");
            });

            modelBuilder.Entity<Receta>(entity =>
            {
                entity.Property(e => e.CategoriaId).HasComment("Si no está nulo significa que es un platillo para vender al publlico");

                entity.Property(e => e.Propiedades).HasComment("Multibandera:\r\n\r\n1 Con costo\r\n2 Temporal\r\n... y las que se requieran posteriormente\r\n\r\n\r\nIngrediente preparado\r\nPlato (para venta)");

                entity.Property(e => e.Receta1).IsUnicode(false);

                entity.Property(e => e.TipoReceta)
                    .IsUnicode(false)
                    .HasComment("Ingrediente preparado\r\nPlato (para venta)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK_Recetas_Menu");
            });

            modelBuilder.Entity<RecetaCocinaArea>(entity =>
            {
                entity.HasKey(e => new { e.RecetaId, e.CocinaAreaId });

                entity.HasOne(d => d.CocinaArea)
                    .WithMany(p => p.RecetaCocinaAreas)
                    .HasForeignKey(d => d.CocinaAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecetaCocinaAreas_CocinaAreas");

                entity.HasOne(d => d.Receta)
                    .WithMany(p => p.RecetaCocinaAreas)
                    .HasForeignKey(d => d.RecetaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecetaCocinaAreas_Recetas");
            });

            modelBuilder.Entity<RecetaIngrediente>(entity =>
            {
                entity.HasKey(e => new { e.RecetaId, e.IngredienteId, e.GrupoIngredienteId });

                entity.Property(e => e.Subgrupo)
                    .IsUnicode(false)
                    .HasComment("Subagrupación de Opciones");

                entity.HasOne(d => d.GrupoIngrediente)
                    .WithMany(p => p.RecetaIngredientes)
                    .HasForeignKey(d => d.GrupoIngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecetaIngredientes_GrupoIngredientes");

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.RecetaIngredientes)
                    .HasForeignKey(d => d.IngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecetaIngredientes_Ingredientes");

                entity.HasOne(d => d.Receta)
                    .WithMany(p => p.RecetaIngredientes)
                    .HasForeignKey(d => d.RecetaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecetaIngredientes_Recetas");
            });

            modelBuilder.Entity<UsuarioCuenta>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CuentaId });

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.UsuarioCuenta)
                    .HasForeignKey(d => d.CuentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioCuentas_Cuentas");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsuarioCuenta)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioCuentas_Usuarios");
            });

            modelBuilder.Entity<UsuarioDato>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsuarioDatos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UsuarioDatos_dbo.Usuarios_UserId");
            });

            modelBuilder.Entity<UsuarioLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.UsuarioLogins");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsuarioLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UsuarioLogins_dbo.Usuarios_UserId");
            });

            modelBuilder.Entity<UsuarioRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.UsuarioRoles");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.UsuarioRoles_dbo.Roles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UsuarioRoles_dbo.Usuarios_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
