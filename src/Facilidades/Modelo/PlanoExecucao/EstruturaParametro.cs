using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Modelo.PlanoExecucao
{
    [Serializable]
    public class EstruturaParametro
    {        
        public List<ParametroPadrao> Parametro { get; set; }
    }
}
