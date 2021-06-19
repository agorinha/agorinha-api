using System.Collections.Generic;
using agorinha_api.Entities.DTO;

namespace agorinha_api.Entities.Repository
{
    public interface ISugestaoRepository
    {
        IEnumerable<LivroDTO> GetSugestoes();

        bool DeleteSugestaoByName(string nome);

        bool AddSugestao(LivroDTO livro);

        bool ClearAll();
    }
}
