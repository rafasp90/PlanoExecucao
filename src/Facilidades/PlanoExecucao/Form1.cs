using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Repositorio;
using System.Linq;
using Modelo.PlanoExecucao;
using System.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace PlanoExecucao
{
    public partial class Form1 : Form
    {
        private readonly string _conexao = "data source={0};Initial Catalog={1};Integrated Security=True;";
        private StringBuilder _log;

        public Form1()
        {
            InitializeComponent();
            CarregarTela();
        }

        private void CarregarTela()
        {
            txtServidor.Text = ConfigurationManager.AppSettings["Servidor"];
            txtBaseDados.Text = ConfigurationManager.AppSettings["BaseDados"];
            txtDiretorioOrigem.Text = ConfigurationManager.AppSettings["DiretorioOrigem"];
            txtDiretorioDestino.Text = ConfigurationManager.AppSettings["DiretorioDestino"];
            SetTextLblProgresso("");
            SetValueProgresso(0);
            _log = new StringBuilder();
            btnResultado.Enabled = false;

            if (!string.IsNullOrWhiteSpace(Program.ErroCarregarParametros))
                MessageBox.Show(Program.ErroCarregarParametros, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private string ObterConexao()
        {
            return string.Format(_conexao, txtServidor.Text.Trim(), txtBaseDados.Text.Trim());
        }

        private async void btnCriar_Click(object sender, EventArgs e)
        {            
            DesabilitarCampos(true);
            try
            {
                if (Validar())
                {
                    this.UseWaitCursor = true;
                    SetTextLblProgresso("Processo iniciado");
                    PlanoExecucaoResult result = await CriarPlanoExecucao();

                    this.UseWaitCursor = false;
                    SetTextLblProgresso("Finalizado");
                    string mensagem = $"Finalizado \n Total Processado: {result.TotalProcessado} \n Total Sucesso: {result.TotalProcessadoSucesso} \n Total Falha: {result.TotalProcessadoErro}";
                    MessageBox.Show(mensagem);
                    btnResultado.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"OOPS! Algo deu errado");
                InserirLog($"Detalhe: {ex}");
                btnResultado.Enabled = true;
            }
            finally
            {
                DesabilitarCampos(false);
            }
        }

        private void DesabilitarCampos(bool desabilitar)
        {
            btnCriar.Enabled = !desabilitar;
            txtDiretorioOrigem.ReadOnly = desabilitar;
            txtDiretorioDestino.ReadOnly = desabilitar;
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtDiretorioOrigem.Text))
            {
                MessageBox.Show("O campo Diretório Origem é obrigatório!");
                return false;
            }

            if (!Directory.Exists(txtDiretorioOrigem.Text.Trim()))
            {
                MessageBox.Show("O diretório origem informado não foi encontrado!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiretorioDestino.Text))
            {
                MessageBox.Show("O campo Diretório Origem é obrigatório!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtServidor.Text))
            {
                MessageBox.Show("O campo Servidor é obrigatório!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBaseDados.Text))
            {
                MessageBox.Show("O campo Base de Dados é obrigatório!");
                return false;
            }

            return true;
        }

        protected void SetTextLblProgresso(string txt)
        {
            if (lblProgresso.InvokeRequired)
                lblProgresso.Invoke(new MethodInvoker(() => lblProgresso.Text = txt));
            else
                lblProgresso.Text = txt;
        }

        protected void SetValueProgresso(int value)
        {
            if (progresso.InvokeRequired)
                progresso.Invoke(new MethodInvoker(() => progresso.Value = value));
            else
                progresso.Value = value;
        }

        protected void SetMaximumProgresso(int value)
        {
            if (progresso.InvokeRequired)
                progresso.Invoke(new MethodInvoker(() => progresso.Maximum = value));
            else
                progresso.Maximum = value;
        }

        private void InserirLog(string value, bool inserirDataHora = true)
        {
            if(inserirDataHora) _log.AppendLine($"Data {DateTime.Now:HH:mm:ss.fff}");
            _log.AppendLine(value);
            _log.AppendLine();
        }

        private List<string> ObterArquivos(string diretorio)
        {            
            string diretorioCorrente = Path.GetFileName(diretorio);
            
            StringBuilder commands = new StringBuilder();

            commands.Append("/C ");
            commands.Append($@"cd {diretorio}");
            commands.Append(" && ");
            commands.Append("cd ..");
            commands.Append(" && ");
            commands.Append($@"git diff --name-only {diretorioCorrente}/ ");

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = commands.ToString(),
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            process.StartInfo = startInfo;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            List<string> procedures = new List<string>();

            foreach(var procedure in output?.Split('\n'))
            {
                procedures.Add(procedure.Substring(procedure.LastIndexOf("/") + 1));
            }

            return procedures;
        }

        private async Task<PlanoExecucaoResult> CriarPlanoExecucao()
        {            
            PlanoExecucaoResult result = new PlanoExecucaoResult();
            _log.Clear();
            try
            {
                DirectoryInfo diretorioOrigem = new DirectoryInfo(txtDiretorioOrigem.Text);

                var arquivos = diretorioOrigem.EnumerateFiles("*.sql", SearchOption.TopDirectoryOnly);

                if (chkIntegrarGit.Checked)
                {
                    var procedures = ObterArquivos(txtDiretorioOrigem.Text);
                    arquivos = arquivos.Where(item => procedures.Any(procedure => procedure.Equals(item.Name))).ToList();
                }

                int contador = 1;
                int total = arquivos.Count();
                SetMaximumProgresso(total);
                string diretorio = string.Empty;

                foreach (FileInfo arquivo in arquivos)
                {
                    try
                    {
                        string nomeArquivo = Path.GetFileNameWithoutExtension(arquivo.FullName);
                        diretorio = Path.Combine(txtDiretorioDestino.Text, nomeArquivo);
                        string texto = $"Item {contador} de {total}: {nomeArquivo}";

                        SetTextLblProgresso(texto);
                        SetValueProgresso(contador);

                        bool existeDiretorio = Directory.Exists(diretorio);
                        if (!existeDiretorio || chkIntegrarGit.Checked)
                        {
                            result.TotalProcessado += 1;
                            if (!existeDiretorio)
                            {
                                Directory.CreateDirectory(diretorio);
                                InserirLog("======================================================================", false);
                                InserirLog($"Procedure: {nomeArquivo}", false);
                                InserirLog($"Novo diretório: {diretorio}");
                            }
                            else
                            {
                                InserirLog($"Diretório existente: {diretorio}");
                            }

                            string nomeArquivoCompleto;

                            //cria arquivo EXEC
                            nomeArquivoCompleto = Path.Combine(diretorio, $"{nomeArquivo}.EXEC.sql");
                            string arquivoExecucao = ObterConteudoArquivoExecucao(nomeArquivo);
                            GravarArquivo(nomeArquivoCompleto, arquivoExecucao.Replace("{GO}", "GO"));
                            InserirLog($"Criado arquivo EXEC: {nomeArquivoCompleto}");

                            InserirLog("Inicio obter statisticas");
                            //obter estatisticas
                            EstatisticaSql estatisticaSql = new Estatistica(ObterConexao()).ObterEstatistaSql(arquivoExecucao.Replace("{GO}", ""));
                            InserirLog("Fim obter statisticas");

                            //cria arquivo IO
                            nomeArquivoCompleto = Path.Combine(diretorio, $"{nomeArquivo}.IO.txt");
                            GravarArquivo(nomeArquivoCompleto, estatisticaSql.EstatisticaIo);
                            InserirLog($"Criado arquivo IO: {nomeArquivoCompleto}");

                            //cria arquivo SQLPLAN
                            nomeArquivoCompleto = Path.Combine(diretorio, $"{nomeArquivo}.sqlplan");
                            GravarArquivo(nomeArquivoCompleto, estatisticaSql.EstatisticaXml);
                            InserirLog($"Criado arquivo SQLPLAN: {nomeArquivoCompleto}");

                            InserirLog("======================================================================", false);
                            result.TotalProcessadoSucesso += 1;
                        }                        
                    }
                    catch (Exception ex)
                    {
                        result.TotalProcessadoErro += 1;
                        InserirLog($"Ocorreu um erro: {ex}");

                        if (!string.IsNullOrWhiteSpace(diretorio))
                        {
                            InserirLog($"Exclusão do diretório [{diretorio}]");
                            Directory.Delete(diretorio, true);
                            InserirLog($"Diretório [{diretorio}] excluido com sucesso ");
                        }
                        InserirLog("======================================================================", false);
                    }
                    
                    contador += 1;
                }

            }
            catch (Exception e)
            {
                InserirLog($"OOPS! Algo deu errado durante a execução. Mensagem: {e.Message}");
                InserirLog($"Detalhe: {e}");
            }
            return await Task.Run(() => result);
        }

        private void GravarArquivo(string caminho, string conteudo)
        {
            File.WriteAllText(caminho, conteudo);            
        }

        private string ObterConteudoArquivoExecucao(string nomeProcedure)
        {
            StringBuilder conteudo = new StringBuilder();
            Informacoes informacoes = new Informacoes(ObterConexao());
            InformacaoProcedure procedure = informacoes.ObterDadosProcedure(nomeProcedure);

            if (procedure == null || string.IsNullOrWhiteSpace(procedure.NomeProcedure))
                throw new Exception($"Procedure {nomeProcedure} não encontrada.");

            conteudo.AppendLine($"USE {txtBaseDados.Text.Trim()}");
            conteudo.AppendLine("{GO}");
            conteudo.AppendLine("BEGIN TRAN");
            conteudo.AppendLine("");
            conteudo.AppendLine("   SET STATISTICS IO ON;");
            conteudo.AppendLine("");
            conteudo.AppendLine($"   EXEC {procedure.Schema}.{procedure.NomeProcedure}");

            int quantidadeParametros = procedure.Parametros.Count;
            int contadorParametros = 1;
            foreach (var parametro in procedure.Parametros)
            {
                conteudo.AppendLine($"      {parametro.NomeParametro} = '{ObterParametroDefault(parametro.NomeParametro, parametro.Tipo)}'{(contadorParametros < quantidadeParametros ? "," : "")}");
                contadorParametros += 1;
            }
            conteudo.AppendLine("");
            conteudo.AppendLine("   SET STATISTICS IO OFF;");
            conteudo.AppendLine("");
            conteudo.AppendLine("ROLLBACK TRAN");
            conteudo.AppendLine("{GO}");

            return conteudo.ToString();
        }

        private string ObterParametroDefault(string nomeParametro, string tipoParametro)
        {
            string parametroAjuste = nomeParametro.Replace("@", "").Trim().ToUpper();

            //var result = Program.EstruturaParametro.Parametro.Where(item => item.Parametros.Any(param => parametroAjuste.Contains(param.Valor.Trim().ToUpper()))).ToList();
            var result = Program.EstruturaParametro?.Parametro?.Where(item => item.Parametros.Any(param => parametroAjuste.Equals(param.Valor.Trim().ToUpper()))).ToList();

            if (result != null && result.Count() > 0)
                return result.First().Valor;

            string resultDefault = "";
            switch (tipoParametro.ToUpper())
            {
                case "CHAR":
                case "VARCHAR":
                    resultDefault = "A";
                    break;
                case "BIT":
                case "SMALLINT":
                case "INT":
                case "BIGINT":
                    resultDefault = "1";
                    break;
                case "DATETIME":
                case "DATE":
                    resultDefault = DateTime.Now.ToString("yyyy-MM-dd");
                    break;
                case "TIME":
                    resultDefault = DateTime.Now.ToString("HH:mm");
                    break;
                case "UNIQUEIDENTIFIER":
                    resultDefault = Guid.NewGuid().ToString();
                    break;
                default:
                    resultDefault = "1";
                    break;
            }
            return resultDefault;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            Detalhe formDetalhe = new Detalhe(_log.ToString());
            formDetalhe.Show();
        }
    }
}
