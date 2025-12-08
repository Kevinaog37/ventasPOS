using System.Data;
using VentasPOS.Domain.Entities;
using Dapper;
using VentasPOS.Application.Interfaces.Usuarios;

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
                return await _db.QueryAsync<Usuario>("sp_ListarUsuarios", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Usuario>();
            }
        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {
            var sql = $"EXEC dbo.sp_ObtenerUsuarioPorId {id}";
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
                                usuario.IdRol
                            },
                            commandType: CommandType.StoredProcedure
                        );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }

        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            try
            {
                Console.WriteLine("Se ejecutó");
                var res = await _db.ExecuteAsync(
                            "sp_ActualizarUsuario",
                                new
                                {
                                    usuario.Id,
                                    usuario.Nombre,
                                    usuario.Correo,
                                    usuario.FechaNacimiento,
                                    usuario.IdRol
                                },
                                commandType: CommandType.StoredProcedure
                            );
                Console.WriteLine("Conteo: " + usuario.Id);
                return res > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se ejecutó");

                Console.WriteLine (ex.Message.ToString());
                return false;
            }

        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                return await _db.ExecuteAsync("sp_EliminarUsuario", new { Id = id }, commandType: CommandType.StoredProcedure) > 0;

            }catch(Exception ex) {
                Console.WriteLine(ex.Message.ToString()); return false;
            }
        }
    }
}