using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasPOS.Application.DTO
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string ?Nombre { get; set; }
        public string ?Correo { get; set; }
        public DateTime FechaNacimiento{ get; set; }
        public string ?Rol { get; set; }
    }
}

