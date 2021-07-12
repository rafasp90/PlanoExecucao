using System.Configuration;

namespace PlanoExecucao
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiretorioOrigem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiretorioDestino = new System.Windows.Forms.TextBox();
            this.btnCriar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBaseDados = new System.Windows.Forms.TextBox();
            this.progresso = new System.Windows.Forms.ProgressBar();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.btnResultado = new System.Windows.Forms.Button();
            this.chkIntegrarGit = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAutenticacao = new System.Windows.Forms.ComboBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta Origem:";
            // 
            // txtDiretorioOrigem
            // 
            this.txtDiretorioOrigem.Location = new System.Drawing.Point(105, 24);
            this.txtDiretorioOrigem.Name = "txtDiretorioOrigem";
            this.txtDiretorioOrigem.Size = new System.Drawing.Size(637, 20);
            this.txtDiretorioOrigem.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pasta Destino:";
            // 
            // txtDiretorioDestino
            // 
            this.txtDiretorioDestino.Location = new System.Drawing.Point(105, 68);
            this.txtDiretorioDestino.Name = "txtDiretorioDestino";
            this.txtDiretorioDestino.Size = new System.Drawing.Size(637, 20);
            this.txtDiretorioDestino.TabIndex = 3;
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(559, 204);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(75, 23);
            this.btnCriar.TabIndex = 4;
            this.btnCriar.Text = "Executar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Servidor:";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(105, 106);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(144, 20);
            this.txtServidor.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Base de Dados:";
            // 
            // txtBaseDados
            // 
            this.txtBaseDados.Location = new System.Drawing.Point(359, 106);
            this.txtBaseDados.Name = "txtBaseDados";
            this.txtBaseDados.Size = new System.Drawing.Size(144, 20);
            this.txtBaseDados.TabIndex = 8;
            // 
            // progresso
            // 
            this.progresso.ForeColor = System.Drawing.Color.DarkGreen;
            this.progresso.Location = new System.Drawing.Point(19, 204);
            this.progresso.Name = "progresso";
            this.progresso.Size = new System.Drawing.Size(511, 23);
            this.progresso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progresso.TabIndex = 9;
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.Location = new System.Drawing.Point(16, 188);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(109, 13);
            this.lblProgresso.TabIndex = 10;
            this.lblProgresso.Text = "Em processamento ...";
            // 
            // btnResultado
            // 
            this.btnResultado.Location = new System.Drawing.Point(640, 205);
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.Size = new System.Drawing.Size(104, 23);
            this.btnResultado.TabIndex = 11;
            this.btnResultado.Text = "Detalhe Processo";
            this.btnResultado.UseVisualStyleBackColor = true;
            this.btnResultado.Click += new System.EventHandler(this.btnResultado_Click);
            // 
            // chkIntegrarGit
            // 
            this.chkIntegrarGit.AutoSize = true;
            this.chkIntegrarGit.Checked = true;
            this.chkIntegrarGit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIntegrarGit.Location = new System.Drawing.Point(651, 94);
            this.chkIntegrarGit.Name = "chkIntegrarGit";
            this.chkIntegrarGit.Size = new System.Drawing.Size(95, 17);
            this.chkIntegrarGit.TabIndex = 12;
            this.chkIntegrarGit.Text = "Repositório Git";
            this.chkIntegrarGit.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Autenticação:";
            // 
            // cbAutenticacao
            // 
            this.cbAutenticacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbAutenticacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAutenticacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutenticacao.FormattingEnabled = true;
            this.cbAutenticacao.Items.AddRange(new object[] {
            "Windows",
            "SQL Server"});
            this.cbAutenticacao.Location = new System.Drawing.Point(105, 138);
            this.cbAutenticacao.Name = "cbAutenticacao";
            this.cbAutenticacao.Size = new System.Drawing.Size(144, 21);
            this.cbAutenticacao.TabIndex = 14;
            this.cbAutenticacao.SelectedIndexChanged += new System.EventHandler(this.cbAutenticacao_SelectedIndexChanged);
            // 
            // txtSenha
            // 
            this.txtSenha.Enabled = false;
            this.txtSenha.Location = new System.Drawing.Point(578, 138);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(164, 20);
            this.txtSenha.TabIndex = 18;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(522, 145);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 17;
            this.lblSenha.Text = "Senha:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(359, 138);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(144, 20);
            this.txtUsuario.TabIndex = 16;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(270, 145);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(36, 13);
            this.lblUsuario.TabIndex = 15;
            this.lblUsuario.Text = "Login:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 250);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.cbAutenticacao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkIntegrarGit);
            this.Controls.Add(this.btnResultado);
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.progresso);
            this.Controls.Add(this.txtBaseDados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.txtDiretorioDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDiretorioOrigem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de Execução - Estrutura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiretorioOrigem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiretorioDestino;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBaseDados;
        private System.Windows.Forms.ProgressBar progresso;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.Button btnResultado;
        private System.Windows.Forms.CheckBox chkIntegrarGit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAutenticacao;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
    }
}

