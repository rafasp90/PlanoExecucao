using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.PlanoExecucao
{
    public class PlanoExecucaoResult
    {
        public int TotalProcessado { get; set; }
        public int TotalProcessadoSucesso { get; set; }
        public int TotalProcessadoErro { get; set; }
    }
}
