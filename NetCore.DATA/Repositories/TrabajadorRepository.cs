using Dapper;
using MySql.Data.MySqlClient;
using NetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.DATA.Repositories
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public TrabajadorRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteTrabajador(Trabajador trabajador)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM trabajadores WHERE id= @Id";
            var result = await db.ExecuteAsync(sql, new {Id = trabajador.Id});
            return result > 0;
        }

        public async Task<IEnumerable<Trabajador>> GetAllTrabajadores()
        {
            var db = dbConnection();

            var sql = @" SELECT id,nombre,apellido,dni,telefono,direccion,cargo,fecha_de_incorporacion from trabajadores";

            return await db.QueryAsync<Trabajador>(sql, new {});
        }

        public async Task<Trabajador> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id,nombre,apellido,dni,telefono,direccion,cargo,fecha_de_incorporacion from trabajadores WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Trabajador>(sql, new { Id = id});
        }

        public async Task<bool> InsertTrabajador(Trabajador trabajador)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO trabajadores (nombre,apellido,dni,telefono,direccion,cargo,fecha_de_incorporacion) VALUES (@Nombre, @Apellido, @Dni, @Telefono, @Direccion, @Cargo, @Fecha_de_incorporacion)";

            var result = await db.ExecuteAsync(sql, new 
            
                {trabajador.Nombre, trabajador.Apellido, trabajador.Dni, trabajador.Telefono, trabajador.Direccion, trabajador.Cargo, trabajador.Fecha_de_incorporacion  });

            return result > 0;
        }

        public async Task<bool> UpdateTrabajador(Trabajador trabajador)
        {
            var db = dbConnection();

            var sql = @"UPDATE  trabajadores
                            SET nombre = @Nombre,
                                apellido = @Apellido,
                                dni = @Dni,
                                telefono = @Telefono,
                                direccion = @Direccion,
                                cargo = @Cargo,
                                fecha_de_incorporacion = @Fecha_de_incorporacion
                              WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new

            { trabajador.Nombre, trabajador.Apellido, trabajador.Dni, trabajador.Telefono, trabajador.Direccion, trabajador.Cargo, trabajador.Fecha_de_incorporacion, trabajador.Id });

            return result > 0;
        }
    }
}
