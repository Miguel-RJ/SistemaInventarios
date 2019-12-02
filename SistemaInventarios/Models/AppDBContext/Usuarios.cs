namespace SistemaInventarios.Models.AppDBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        [StringLength(20)]
        public string IdUser { get; set; }

        [StringLength(25)]
        public string Pass { get; set; }

        [StringLength(75)]
        public string Nombre { get; set; }

        [StringLength(1)]
        public string IdRol { get; set; }

        [StringLength(30)]
        public string Palabra { get; set; }

        public bool? Sesion { get; set; }

        public virtual RolesUsuarios RolesUsuarios { get; set; }
    }
}
