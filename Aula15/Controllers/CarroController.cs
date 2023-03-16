using Aula15.Model;
using Microsoft.AspNetCore.Mvc;

namespace Aula15.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ILogger<CarroController> _logger;

        public CarroController(ILogger<CarroController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool CadastrarPessoa(Carro carro)
        {
            Carro variavelCarro = new Carro();
            return variavelCarro.CadastrarCarro(carro) > 0;
        }

        [HttpGet]
        [Route("BuscarCarros")]
        public List<Carro> BuscarCarros()
        {
            Carro variavelCarro = new Carro();
            return variavelCarro.BuscarCarro();
        }

        [HttpDelete]
        [Route("DeletarCarro")]
        public bool DeletarCarro(string modelo)
        {
            Carro variavelCarro = new Carro();
            return variavelCarro.DeletarCarro(modelo);
        }

        [HttpPut]
        [Route("AtualizarCarro")]
        public bool AtualizarCarro(Carro carro)
        {
            Carro variavelCarro = new Carro();
            return variavelCarro.AtualizarCarro(carro);
        }
    }   
}