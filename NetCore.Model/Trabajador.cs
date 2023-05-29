using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Model
{
    public class Trabajador
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set;}

        public string? Dni {get; set;}

        public string? Telefono { get; set;}

        public string? Direccion { get; set;}

        public string? Cargo { get; set;}

        public string? Fecha_de_incorporacion { get; set;}

       

    }
}
