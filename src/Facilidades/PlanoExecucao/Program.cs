using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modelo.PlanoExecucao;
using Utils;
using System.Configuration;
using System.Xml;

namespace PlanoExecucao
{
    internal static class Program
    {

        public static EstruturaParametro EstruturaParametro { get; set; }
        public static string ErroCarregarParametros { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            CarregarParametros();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void CarregarParametros()
        {
            string config = ConfigurationManager.AppSettings["ParametroDefault"];
            try
            {
                
                if (config != null)
                {
                    XmlDocument docXml = new XmlDocument();
                    docXml.Load(config);
                    EstruturaParametro = SerializacaoXml.Desserializar<EstruturaParametro>(docXml.OuterXml);
                }
            }
            catch (Exception ex)
            {                
                ErroCarregarParametros = $"Não foi possível carregar os parametros! \n Mensagem: {ex.Message}";
            }            
        }
    }
}