using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasPOS.Application.DTO
{
    public class UsuarioCrearDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Rol { get; set; } = string.Empty;
    }
}
