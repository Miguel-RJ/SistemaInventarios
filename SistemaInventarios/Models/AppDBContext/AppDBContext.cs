namespace SistemaInventarios.Models.AppDBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
            : base("name=AppDBContext1")
        {
        }

        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<RolesUsuarios> RolesUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>()
                .Property(e => e.NombreArt)
                .IsUnicode(false);

            modelBuilder.Entity<Articulos>()
                .Property(e => e.DescripcionArt)
                .IsUnicode(false);

            modelBuilder.Entity<RolesUsuarios>()
                .Property(e => e.IdRol)
                .IsUnicode(false);

            modelBuilder.Entity<RolesUsuarios>()
                .Property(e => e.NombreRol)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.IdUser)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.IdRol)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Palabra)
                .IsUnicode(false);
        }
    }
}
