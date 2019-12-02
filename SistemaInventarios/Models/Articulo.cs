using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventarios.Models
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string NombreArt { get; set; }
        public int CantidadArt { get; set; }
        public string DescripcionArt { get; set; }
    }
}