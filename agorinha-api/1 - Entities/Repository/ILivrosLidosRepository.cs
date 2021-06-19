using System.Collections.Generic;
using agorinha_api.Entities.DTO;

namespace agorinha_api.Entities.Repository
{
    public interface ILivrosLidosRepository
    {
        IEnumerable<LivroDTO> GetLivrosLidos();

        bool DeleteLivroLidoByName(string nome);

        bool AddLivroLido(LivroDTO livro);
    }
}
