using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Modelo.PlanoExecucao
{
    [Serializable]
    public class ParametroPadrao
    {
        [XmlAttribute]
        public string Valor { get; set; }

        
        public List<NomeParametroConsiderar> Parametros { get; set; }
    }
}
