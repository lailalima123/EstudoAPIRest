using Dapper;
using MySqlConnector;

namespace Aula15.Model
{
    public class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime Ano { get; set; }
        public string Cor { get; set; }
        public int PessoaId { get; set; }

        public int CadastrarCarro(Carro carro)
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlInsert = @"INSERT INTO carro (Marca, Modelo, Ano, Cor, PessoaId)
                                      VALUE (@par_marca, @par_modelo, @par_ano, @par_cor, @par_pessoa_id)";
                return conexao.Execute(mySqlInsert,
                                              new
                                              {
                                                  @par_marca = carro.Marca,
                                                  @par_modelo = carro.Modelo,
                                                  @par_ano = carro.Ano,
                                                  @par_cor = carro.Cor,
                                                  @par_pessoa_id = carro.PessoaId,
                                              });
            }
        }
        public List<Carro> BuscarCarro()
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlInsert = @"SELECT Marca, Modelo, Ano, Cor, PessoaId FROM carro";
                return conexao.Query<Carro>(mySqlInsert).AsList<Carro>();
            }         
        }
        public bool DeletarCarro(string modelo)
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlDelete = @"DELETE FROM carro where modelo= @par_modelo";
                int retorno = conexao.Execute(mySqlDelete, new
                {
                    par_modelo = modelo
                });
                return retorno > 0;
            }
        }
        public bool AtualizarCarro(Carro carro)
        {
            using (MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=banco_dados_mvc; user=root; password=31052016kl;port=3306"))
            {
                string mySqlUpdate = @"UPDATE tabela_carro SET @par_marca, @par_modelo, @par_ano, @par_cor, @par_pessoa_id";
                int retorno = conexao.Execute(mySqlUpdate, new
                {
                    @par_marca = carro.Marca,
                    @par_modelo = carro.Modelo,
                    @par_ano = carro.Ano,
                    @par_cor = carro.Cor,
                    @par_pessoa_id = carro.PessoaId,
                });
                return retorno > 0;
            }
        }
    }
}