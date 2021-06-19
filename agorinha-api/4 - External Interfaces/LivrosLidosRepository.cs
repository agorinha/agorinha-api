using System;
using System.Collections.Generic;
using agorinha_api.Entities.DTO;
using agorinha_api.Entities.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace agorinha_api.ExternalInterfaces
{
    public class LivrosLidosRepository : ILivrosLidosRepository
    {
        private readonly string _connectionString;

        public LivrosLidosRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }


        public IEnumerable<LivroDTO> GetLivrosLidos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var results = connection.Query<LivroDTO>("SELECT * FROM LivrosLidos");
                connection.Close();

                return results;
            }
        }

        public bool AddLivroLido(LivroDTO livro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                            Insert into LivrosLidos Values (@Name, @Autor, @Ano, @Genero, @Sinopse)
                        ";

                connection.Query(query, new { Name = livro.Name, Autor = livro.Autor, Ano = livro.Ano, Genero = livro.Genero, Sinopse = livro.Sinopse });
                connection.Close();
                return true;
            }
        }

        public bool DeleteLivroLidoByName(string nome)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"DELETE FROM LivrosLidos WHERE Name = @Name;";
                connection.Query(query, new { Name = nome });
                connection.Close();
                return true;
            }
        }
    }
}
