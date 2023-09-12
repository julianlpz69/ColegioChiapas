using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Telefono {get; set;}
        public string Dirreccion {get; set;}
        public string Documento {get; set;}
    }
}