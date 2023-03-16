using Aula15.Model;
using Microsoft.AspNetCore.Mvc;

namespace Aula15.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {      
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool CadastrarPessoa(Pessoa pessoa)
        {
            Pessoa variavelPessoa = new Pessoa();
            return variavelPessoa.CadastrarPessoa(pessoa) > 0;
        }

        [HttpGet]
        [Route ("BuscarPessoas")]
        public List<Pessoa> BuscarPessoas()
        {
            Pessoa variavelPessoa = new Pessoa();
            return variavelPessoa.BuscarPessoa();
        }

        [HttpGet]
        [Route("BuscarPessoaPorCpf")]
        public Pessoa BuscarPessoaPorCpf(string cpf)
        {
            Pessoa variavelPessoa = new Pessoa();
            return variavelPessoa.BuscarPessoaCpf(cpf);
        }

        [HttpDelete]
        [Route("DeletarPessoa")]
        public bool DeletarPessoa(string cpf)
        {
            Pessoa variavelPessoa = new Pessoa();
            return variavelPessoa.DeletarPessoa(cpf);
        }

        [HttpPut]
        [Route("AtualizarPessoa")]
        public bool AtualizarPessoa(Pessoa pessoa)
        {
            Pessoa variavelPessoa = new Pessoa();
            return variavelPessoa.AtualizarPessoa(pessoa);
        }
    }
}