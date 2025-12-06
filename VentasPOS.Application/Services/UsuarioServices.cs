using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.DTO;
using VentasPOS.Application.Interfaces;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UsuarioDto>> Listar()
        {
            var data = await _repo.Listar();
            
            var res= data.Select(x => new UsuarioDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Correo = x.Correo,
                FechaNacimiento = x.FechaNacimiento,
                Rol = x.Rol
            });
            
            return res;
        }

        public async Task<UsuarioDto?> ObtenerPorId(int id)
        {
            var x = await _repo.ObtenerPorId(id);
            if (x == null) return null;

            return new UsuarioDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Correo = x.Correo,
                FechaNacimiento = x.FechaNacimiento,
                Rol = x.Rol
            };
        }

        public async Task<int> Crear(UsuarioCrearDto dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Clave = BCrypt.Net.BCrypt.HashPassword(dto.Clave),
                FechaNacimiento = dto.FechaNacimiento,
                Rol = dto.Rol
            };

            return await _repo.Crear(usuario);
        }

        public async Task<bool> Actualizar(int id, UsuarioCrearDto dto)
        {
            var usuario = new Usuario
            {
                Id = id,
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Clave = BCrypt.Net.BCrypt.HashPassword(dto.Clave),
                FechaNacimiento = dto.FechaNacimiento,
                Rol = dto.Rol
            };

            return await _repo.Actualizar(usuario);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repo.Eliminar(id);
        }
    }
}