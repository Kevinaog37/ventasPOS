using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.Interfaces;
using VentasPOS.Domain.Entities;
using Dapper;

namespace VentasPOS.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _db;

        public UsuarioRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Usuario>> Listar()
        {
            try
            {
                return await _db.QueryAsync<Usuario>(
                                "sp_ListarUsuarios",
                                commandType: CommandType.StoredProcedure
                            );
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Usuario>();
            }
            
            /*await Task.Delay(0);
            return new List<Usuario>
            {
                new Usuario{Id = 1, Nombre="Kevin", Clave ="lllll", FechaNacimiento = DateTime.Parse("2010-12-01"), Correo = "Pruebas@gmail.com", Rol="1"},
                new Usuario{Id = 1, Nombre="Arlex", Clave ="newhas20311", FechaNacimiento = DateTime.Parse("2001-06-05"), Correo = "Arlex@gmail.com", Rol="2"},
                new Usuario{Id = 1, Nombre="Pruebas", Clave ="kzjsdasdlla", FechaNacimiento = DateTime.Parse("2001-06-05"), Correo = "Arlex@gmail.com", Rol="3"},
            };*/
        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {
            var sql = "SELECT * FROM Usuarios WHERE Id = @Id";
            return await _db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<int> Crear(Usuario usuario)
        {
            try
            {
                return await _db.ExecuteScalarAsync<int>(
                        "sp_InsertarUsuario",
                            new
                            {
                                usuario.Nombre,
                                usuario.Correo,
                                usuario.Clave,
                                usuario.FechaNacimiento,
                                usuario.Rol
                            },
                            commandType: CommandType.StoredProcedure
                        );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() ); 
                return -1;
            }
            
        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            var sql = @"UPDATE Usuarios SET
                    Nombre = @Nombre,
                    Correo = @Correo,
                    ClaveHash = @ClaveHash,
                    FechaNacimiento = @FechaNacimiento,
                    Rol = @Rol
                    WHERE Id = @Id";
            return await _db.ExecuteAsync(sql, usuario) > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sql = "DELETE FROM Usuarios WHERE Id = @Id";
            return await _db.ExecuteAsync(sql, new { Id = id }) > 0;
        }
    }
}