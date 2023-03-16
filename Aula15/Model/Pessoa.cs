using Dapper;
using MySqlConnector;
using System.Data;

namespace Aula15.Model
{
    public class Pessoa
    {
        public string NomePessoa { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public int IdPessoa { get; set; }

        public int CadastrarPessoa(Pessoa pessoa)
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlInsert = @"INSERT INTO pessoa (NomePessoa, Idade, Cpf)
                                      VALUE (@par_nome_pessoa, @par_Idade, @par_cpf)";
                return conexao.Execute(mySqlInsert,
                                              new
                                              {
                                                  par_nome_pessoa = pessoa.NomePessoa,
                                                  par_idade = pessoa.Idade,
                                                  par_cpf = pessoa.Cpf,
                                              });
            }
        }
        public List<Pessoa> BuscarPessoa()
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlInsert = @"SELECT NomePessoa, Idade, Cpf, IdPessoa FROM pessoa";
                return conexao.Query<Pessoa>(mySqlInsert).AsList<Pessoa>();
            }
        }
        public Pessoa BuscarPessoaCpf(string cpf)
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlInsert = @"SELECT NomePessoa, Idade, Cpf FROM pessoa where Cpf = @par_cpf";
                return conexao.Query<Pessoa>(mySqlInsert, new { par_Cpf = cpf }).FirstOrDefault();
            }
        }
        public bool DeletarPessoa(string cpf)
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlDelete = @"DELETE FROM pessoa where cpf = @par_cpf";
                int retorno = conexao.Execute(mySqlDelete, new
                {
                    par_Cpf = cpf
                });
                return retorno > 0;
            }
        }
        public bool AtualizarPessoa(Pessoa pessoa)
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlUpdate = @"UPDATE tabela_pessoa SET @par_nome_pessoa = NomePessa, @par_cpf = Cpf, @par_idade = Idade";
                int retorno = conexao.Execute(mySqlUpdate, new
                {
                    par_nome = pessoa.NomePessoa,
                    par_cpf = pessoa.Cpf,
                    par_idade = pessoa.Idade
                });
                return retorno > 0;
            }

        }    
    }
}
