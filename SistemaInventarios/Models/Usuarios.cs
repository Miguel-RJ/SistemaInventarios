using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventarios.Models
{
    public class Usuarios
    {
        public string IdUser { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string IdRol { get; set; }
        public string Palabra { get; set; }
    }
}