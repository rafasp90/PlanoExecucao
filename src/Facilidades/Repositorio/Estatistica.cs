using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Modelo.PlanoExecucao;
using Utils;

namespace Repositorio
{
    public class Estatistica
    {
        private string _estatisticaIo = "";
        private readonly string _conexao;

        public Estatistica(string conexao)
        {
            _conexao = conexao;
        }
        
        public EstatisticaSql ObterEstatistaSql(string query)
        {
            StringBuilder comandoSql = new StringBuilder();
            XmlDocument docXmlPlanSql = new XmlDocument();
            if (!query.Contains("STATISTICS XML"))
                comandoSql.AppendLine("SET STATISTICS XML ON");

            if (!query.Contains("STATISTICS IO"))
                comandoSql.AppendLine("SET STATISTICS IO ON");

            comandoSql.AppendLine(query);

            using (SqlConnection connection = new SqlConnection(_conexao))
            {                
                connection.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
                SqlCommand command = new SqlCommand(comandoSql.ToString(), connection);
                connection.Open();

                command.CommandTimeout = 600;

                SqlDataReader reader = command.ExecuteReader();
                
                do
                {
                    if (reader.Read())
                    {
                        string result = reader.GetValue(0).ToString();
                        if (result.StartsWith("<ShowPlanXML"))
                        {
                            var docXml = new XmlDocument();
                            docXml.LoadXml(result);
                            if (docXmlPlanSql.HasChildNodes)
                            {
                                foreach (XmlNode item in docXml.FirstChild.FirstChild.ChildNodes)
                                {
                                    docXmlPlanSql.FirstChild.FirstChild.AppendChild(docXmlPlanSql.ImportNode(item, true));
                                }
                            }
                            else
                            {
                               docXmlPlanSql.AppendChild(docXmlPlanSql.ImportNode(docXml.FirstChild, true));
                            }
                        }
                    }                    
                } while (reader.NextResult());

                reader.Close();
                connection.Close();
            }

            return new EstatisticaSql {
                EstatisticaIo = _estatisticaIo,
                EstatisticaXml = docXmlPlanSql.OuterXmlFormatter()
            };
        }

        private void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
        {
            _estatisticaIo = _estatisticaIo + e.Message + Environment.NewLine;
        }

    }
}
