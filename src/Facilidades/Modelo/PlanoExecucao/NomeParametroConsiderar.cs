using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Modelo.PlanoExecucao
{
    [Serializable]
    public class NomeParametroConsiderar
    {
        [XmlAttribute]
        public string Valor { get; set; }
    }
}