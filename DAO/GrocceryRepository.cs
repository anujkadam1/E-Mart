using E_Mart.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using E_Mart.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using E_Mart.DAO.Interfaces;

namespace E_Mart.DAO
{
    public class GrocceryRepository : IGrocceryRepository
    {
        private readonly string? _connectionString;

        public GrocceryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Groccery>> GetAllGrocceriesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Groccery";
                return await connection.QueryAsync<Groccery>(query);
            }
        }

        public async Task<Groccery> GetGrocceryByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Groccery WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<Groccery>(query, new { Id = id });
            }
        }

        public async Task<bool> AddGrocceryAsync(Groccery groccery)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    var query = "INSERT INTO Groccery (Name, Price) VALUES (@Name, @Price)";
                    await connection.ExecuteAsync(query, groccery);
                    return true;
                        }
                catch(Exception e)
                {
                    return false;
                }
            }
        }

        public async Task UpdateGrocceryAsync(Groccery groccery)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE Groccery SET Name = @Name, Price = @Price WHERE Id = @Id";
                await connection.ExecuteAsync(query, groccery);
            }
        }

        public async Task DeleteGrocceryAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Groccery WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
