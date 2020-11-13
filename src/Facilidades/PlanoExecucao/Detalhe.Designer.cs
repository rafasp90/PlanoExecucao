namespace PlanoExecucao
{
    partial class Detalhe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detalhe));
            this.txtDetalhe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDetalhe
            // 
            this.txtDetalhe.Location = new System.Drawing.Point(6, 12);
            this.txtDetalhe.Multiline = true;
            this.txtDetalhe.Name = "txtDetalhe";
            this.txtDetalhe.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetalhe.Size = new System.Drawing.Size(782, 426);
            this.txtDetalhe.TabIndex = 0;
            // 
            // Detalhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDetalhe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Detalhe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de Execução - Detalhe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDetalhe;
    }
}