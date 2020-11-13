using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Informacoes
    {
        private readonly string _conexao;

        public Informacoes(string conexao)
        {
            _conexao = conexao;
        }

        public InformacaoProcedure ObterDadosProcedure(string nomeProcedure)
        {
            InformacaoProcedure informacao = new InformacaoProcedure();

            using (SqlConnection connection = new SqlConnection(_conexao))
            {
                SqlCommand command = new SqlCommand(Queries.QueryInformacaoProcedure(nomeProcedure), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    informacao.NomeProcedure = reader["NomeProcedure"].ToString();
                    informacao.Schema = reader["NomeSchema"].ToString();                    
                }
                reader.Close();

                command = new SqlCommand(Queries.QueryInformacaoParametros(nomeProcedure), connection);
                
                reader = command.ExecuteReader();

                informacao.Parametros = new List<ParametroProcedure>();

                while (reader.Read())
                {
                    var parametro = new ParametroProcedure
                    {
                        NomeParametro = reader["NomeParametro"].ToString(),
                        Tamanho = (int)reader["Tamanho"],
                        Tipo = reader["Tipo"].ToString()                        
                    };
                    informacao.Parametros.Add(parametro);
                }

                reader.Close();

                connection.Close();               
            }

            return informacao;
        }
    }

    public class InformacaoProcedure
    {
        public string NomeProcedure { get; set; }
        public string Schema { get; set; }
        public List<ParametroProcedure> Parametros { get; set; }
    }

    public class ParametroProcedure
    {
        public string NomeParametro { get; set; }
        public string Tipo { get; set; }
        public int Tamanho { get; set; }
    }
}
