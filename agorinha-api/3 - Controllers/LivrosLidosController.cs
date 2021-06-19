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
    public class LivrosLidosController : Controller
    {
        private ILivrosLidosRepository _livrosLidosRepository { get; }
        private readonly ILogger<LivrosLidosController> _logger;
        public LivrosLidosController(ILogger<LivrosLidosController> logger, ILivrosLidosRepository livrosLidosRepository)
        {
            _logger = logger;
            _livrosLidosRepository = livrosLidosRepository;
        }


        [HttpGet("GetAll")]
        public IEnumerable<LivroDTO> GetLivrosLidos()
        {
            return _livrosLidosRepository.GetLivrosLidos();
        }

        [HttpPost("Add")]
        public bool AddSugestao([FromBody] LivroDTO livro)
        {
            return _livrosLidosRepository.AddLivroLido(livro);
        }

        [HttpPost("Delete")]
        public bool DeleteLivroLidoByName(string nome)
        {
            return _livrosLidosRepository.DeleteLivroLidoByName(nome);
        }

    }
}
