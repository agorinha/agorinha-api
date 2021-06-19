using System;
using System.Collections.Generic;
using agorinha_api.Entities.DTO;
using agorinha_api.Entities.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace agorinha_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SugestaoController : Controller
    {
        private ISugestaoRepository _sugestaoRepository { get; }
        private readonly ILogger<SugestaoController> _logger;
        public SugestaoController(ILogger<SugestaoController> logger, ISugestaoRepository sugestaoRepository)
        {
            _logger = logger;
            _sugestaoRepository = sugestaoRepository;
        }


        [HttpGet("GetAll")]
        public IEnumerable<LivroDTO> GetSugestoes()
        {
            return _sugestaoRepository.GetSugestoes();
        }

        [HttpPost("Add")]
        public bool AddSugestao([FromBody] LivroDTO livro)
        {
            return _sugestaoRepository.AddSugestao(livro);
        }

        [HttpPost("Delete")]
        public bool DeleteSugestaoByName(string nome)
        {
            return _sugestaoRepository.DeleteSugestaoByName(nome);
        }

        [HttpPost("DeleteAll")]
        public bool ClearAll([FromBody] string password)
        {
            if(password == "agorinha")
            {
                return _sugestaoRepository.ClearAll();
            }
            else
            {
                return false;
            }

        }


    }
}
