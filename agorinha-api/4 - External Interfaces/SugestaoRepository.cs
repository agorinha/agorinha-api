using System.Collections.Generic;
using agorinha_api.Entities.DTO;
using agorinha_api.Entities.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace agorinha_api.ExternalInterfaces
{
    public class SugestaoRepository : ISugestaoRepository
    {
        private readonly string _connectionString;

        public SugestaoRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
    

        public bool AddSugestao(LivroDTO livro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                            Insert into Sugestoes Values (@Name, @Autor, @Ano, @Genero, @Sinopse)
                        ";

                connection.Query(query, new { Name = livro.Name, Autor = livro.Autor, Ano = livro.Ano, Genero = livro.Genero, Sinopse = livro.Sinopse });
                connection.Close();
                return true;

            }
        }

        public bool ClearAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"DELETE FROM Sugestoes;";
                connection.Query(query);
                connection.Close();
                return true;
            }
        }

        public bool DeleteSugestaoByName(string nome)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"DELETE FROM Sugestoes WHERE Name = @Name;";
                connection.Query(query, new { Name = nome});
                connection.Close();
                return true;
            }
        }

        public IEnumerable<LivroDTO> GetSugestoes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var results = connection.Query<LivroDTO>("SELECT * FROM Sugestoes");
                connection.Close();

                return results;
            }
        }
    }
}
