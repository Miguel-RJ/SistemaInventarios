namespace SistemaInventarios.Models.AppDBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Articulos")]
    public partial class Articulo
    {
        [Key]
        public int IdArticulo { get; set; }

        [StringLength(50)]
        public string NombreArt { get; set; }

        public int? CantidadArt { get; set; }

        [StringLength(200)]
        public string DescripcionArt { get; set; }
    }
}
