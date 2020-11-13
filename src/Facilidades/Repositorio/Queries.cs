using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Queries
    {
        public static string QueryInformacaoProcedure(string nomeProcedure)
        {
            return $@"
            SELECT
	            SPECIFIC_SCHEMA AS NomeSchema,
	            SPECIFIC_NAME AS NomeProcedure
            FROM information_schema.ROUTINES
            WHERE 
	            SPECIFIC_NAME = '{nomeProcedure}'";
        }

        public static string QueryInformacaoParametros(string nomeProcedure)
        {
            return $@"
            SELECT	
	            PARAMETER_NAME AS NomeParametro,
	            DATA_TYPE AS Tipo,
	            ISNULL(CHARACTER_MAXIMUM_LENGTH, 0) AS Tamanho
            FROM 
	            information_schema.parameters
            WHERE 
	            SPECIFIC_NAME = '{nomeProcedure}'
            ORDER BY 
	            ORDINAL_POSITION";
        }
    }
}
