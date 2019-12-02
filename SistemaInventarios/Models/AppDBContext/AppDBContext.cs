namespace SistemaInventarios.Models.AppDBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
            : base("name=AppDBContext")
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>()
                .Property(e => e.NombreArt)
                .IsUnicode(false);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.DescripcionArt)
                .IsUnicode(false);

            modelBuilder.Entity<RolesUsuario>()
                .Property(e => e.IdRol)
                .IsUnicode(false);

            modelBuilder.Entity<RolesUsuario>()
                .Property(e => e.NombreRol)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.IdUser)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.IdRol)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Palabra)
                .IsUnicode(false);
        }
    }
}
