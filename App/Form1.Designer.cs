namespace App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            btnCancelaBoleto = new System.Windows.Forms.Button();
            btnGeraboleto = new System.Windows.Forms.Button();
            btnCriarBoleto = new System.Windows.Forms.Button();
            btnBuscarBoleto = new System.Windows.Forms.Button();
            btnBuscarSumario = new System.Windows.Forms.Button();
            btnBuscarVariosBoletos = new System.Windows.Forms.Button();
            tabPage3 = new System.Windows.Forms.TabPage();
            btnPixVencimentoBuscar = new System.Windows.Forms.Button();
            btPixVencimentoBuscarUm = new System.Windows.Forms.Button();
            btnPixVencimentoAtualizar = new System.Windows.Forms.Button();
            btnCriarPixVencimento = new System.Windows.Forms.Button();
            btnCriaPixCom = new System.Windows.Forms.Button();
            btnCriaPixSem = new System.Windows.Forms.Button();
            btnConsultaVarios = new System.Windows.Forms.Button();
            btnConsultaPix = new System.Windows.Forms.Button();
            btnAtualizaPixImediato = new System.Windows.Forms.Button();
            btnConsultarDevolucao = new System.Windows.Forms.Button();
            btnSolicitarDevolucao = new System.Windows.Forms.Button();
            btnConsultarPixRecebidos = new System.Windows.Forms.Button();
            btnConsultarPix = new System.Windows.Forms.Button();
            tabPage2 = new System.Windows.Forms.TabPage();
            txtRetorno = new System.Windows.Forms.TextBox();
            tabControl2 = new System.Windows.Forms.TabControl();
            label22 = new System.Windows.Forms.Label();
            txtClientId = new System.Windows.Forms.TextBox();
            txtClientSecret = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            btnInicializar = new System.Windows.Forms.Button();
            lblOnOff = new System.Windows.Forms.Label();
            txtScopes = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage2.SuspendLayout();
            tabControl2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new System.Drawing.Point(12, 51);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(760, 231);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnCancelaBoleto);
            tabPage1.Controls.Add(btnGeraboleto);
            tabPage1.Controls.Add(btnCriarBoleto);
            tabPage1.Controls.Add(btnBuscarBoleto);
            tabPage1.Controls.Add(btnBuscarSumario);
            tabPage1.Controls.Add(btnBuscarVariosBoletos);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(752, 203);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Boleto";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCancelaBoleto
            // 
            btnCancelaBoleto.Location = new System.Drawing.Point(163, 100);
            btnCancelaBoleto.Name = "btnCancelaBoleto";
            btnCancelaBoleto.Size = new System.Drawing.Size(151, 41);
            btnCancelaBoleto.TabIndex = 6;
            btnCancelaBoleto.Text = "Cancelar Boleto";
            btnCancelaBoleto.UseVisualStyleBackColor = true;
            btnCancelaBoleto.Click += btnCancelaBoleto_Click;
            // 
            // btnGeraboleto
            // 
            btnGeraboleto.Location = new System.Drawing.Point(6, 100);
            btnGeraboleto.Name = "btnGeraboleto";
            btnGeraboleto.Size = new System.Drawing.Size(151, 41);
            btnGeraboleto.TabIndex = 5;
            btnGeraboleto.Text = "Gerar PDF";
            btnGeraboleto.UseVisualStyleBackColor = true;
            btnGeraboleto.Click += btnGeraboleto_Click;
            // 
            // btnCriarBoleto
            // 
            btnCriarBoleto.Location = new System.Drawing.Point(163, 53);
            btnCriarBoleto.Name = "btnCriarBoleto";
            btnCriarBoleto.Size = new System.Drawing.Size(151, 41);
            btnCriarBoleto.TabIndex = 4;
            btnCriarBoleto.Text = "Criar Boleto";
            btnCriarBoleto.UseVisualStyleBackColor = true;
            btnCriarBoleto.Click += btnCriarBoleto_Click;
            // 
            // btnBuscarBoleto
            // 
            btnBuscarBoleto.Location = new System.Drawing.Point(163, 6);
            btnBuscarBoleto.Name = "btnBuscarBoleto";
            btnBuscarBoleto.Size = new System.Drawing.Size(151, 41);
            btnBuscarBoleto.TabIndex = 2;
            btnBuscarBoleto.Text = "Buscar Boleto";
            btnBuscarBoleto.UseVisualStyleBackColor = true;
            btnBuscarBoleto.Click += btnBuscarBoleto_Click;
            // 
            // btnBuscarSumario
            // 
            btnBuscarSumario.Location = new System.Drawing.Point(6, 53);
            btnBuscarSumario.Name = "btnBuscarSumario";
            btnBuscarSumario.Size = new System.Drawing.Size(151, 41);
            btnBuscarSumario.TabIndex = 1;
            btnBuscarSumario.Text = "Buscar Sumario";
            btnBuscarSumario.UseVisualStyleBackColor = true;
            btnBuscarSumario.Click += btnBuscarSumario_Click;
            // 
            // btnBuscarVariosBoletos
            // 
            btnBuscarVariosBoletos.Location = new System.Drawing.Point(6, 6);
            btnBuscarVariosBoletos.Name = "btnBuscarVariosBoletos";
            btnBuscarVariosBoletos.Size = new System.Drawing.Size(151, 41);
            btnBuscarVariosBoletos.TabIndex = 0;
            btnBuscarVariosBoletos.Text = "Buscar Varios Boletos";
            btnBuscarVariosBoletos.UseVisualStyleBackColor = true;
            btnBuscarVariosBoletos.Click += btnBuscarVariosBoletos_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnPixVencimentoBuscar);
            tabPage3.Controls.Add(btPixVencimentoBuscarUm);
            tabPage3.Controls.Add(btnPixVencimentoAtualizar);
            tabPage3.Controls.Add(btnCriarPixVencimento);
            tabPage3.Controls.Add(btnCriaPixCom);
            tabPage3.Controls.Add(btnCriaPixSem);
            tabPage3.Controls.Add(btnConsultaVarios);
            tabPage3.Controls.Add(btnConsultaPix);
            tabPage3.Controls.Add(btnAtualizaPixImediato);
            tabPage3.Controls.Add(btnConsultarDevolucao);
            tabPage3.Controls.Add(btnSolicitarDevolucao);
            tabPage3.Controls.Add(btnConsultarPixRecebidos);
            tabPage3.Controls.Add(btnConsultarPix);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(3);
            tabPage3.Size = new System.Drawing.Size(752, 203);
            tabPage3.TabIndex = 1;
            tabPage3.Text = "Pix";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnPixVencimentoBuscar
            // 
            btnPixVencimentoBuscar.Location = new System.Drawing.Point(477, 6);
            btnPixVencimentoBuscar.Name = "btnPixVencimentoBuscar";
            btnPixVencimentoBuscar.Size = new System.Drawing.Size(151, 41);
            btnPixVencimentoBuscar.TabIndex = 13;
            btnPixVencimentoBuscar.Text = "Buscar Varios Pix com Vencimento";
            btnPixVencimentoBuscar.UseVisualStyleBackColor = true;
            btnPixVencimentoBuscar.Click += btnPixVencimentoBuscar_Click;
            // 
            // btPixVencimentoBuscarUm
            // 
            btPixVencimentoBuscarUm.Location = new System.Drawing.Point(320, 147);
            btPixVencimentoBuscarUm.Name = "btPixVencimentoBuscarUm";
            btPixVencimentoBuscarUm.Size = new System.Drawing.Size(151, 41);
            btPixVencimentoBuscarUm.TabIndex = 12;
            btPixVencimentoBuscarUm.Text = "Buscar um Pix com Vencimento";
            btPixVencimentoBuscarUm.UseVisualStyleBackColor = true;
            btPixVencimentoBuscarUm.Click += btPixVencimentoBuscarUm_Click;
            // 
            // btnPixVencimentoAtualizar
            // 
            btnPixVencimentoAtualizar.Location = new System.Drawing.Point(320, 100);
            btnPixVencimentoAtualizar.Name = "btnPixVencimentoAtualizar";
            btnPixVencimentoAtualizar.Size = new System.Drawing.Size(151, 41);
            btnPixVencimentoAtualizar.TabIndex = 11;
            btnPixVencimentoAtualizar.Text = "Atualizar Pix com vencimento";
            btnPixVencimentoAtualizar.UseVisualStyleBackColor = true;
            btnPixVencimentoAtualizar.Click += btnPixVencimentoAtualizar_Click;
            // 
            // btnCriarPixVencimento
            // 
            btnCriarPixVencimento.Location = new System.Drawing.Point(320, 53);
            btnCriarPixVencimento.Name = "btnCriarPixVencimento";
            btnCriarPixVencimento.Size = new System.Drawing.Size(151, 41);
            btnCriarPixVencimento.TabIndex = 10;
            btnCriarPixVencimento.Text = "Criar Pix com vencimento";
            btnCriarPixVencimento.UseVisualStyleBackColor = true;
            btnCriarPixVencimento.Click += btnCriarPixVencimento_Click;
            // 
            // btnCriaPixCom
            // 
            btnCriaPixCom.Location = new System.Drawing.Point(320, 6);
            btnCriaPixCom.Name = "btnCriaPixCom";
            btnCriaPixCom.Size = new System.Drawing.Size(151, 41);
            btnCriaPixCom.TabIndex = 9;
            btnCriaPixCom.Text = "Criar Pix Imediato\r\n(com txid)";
            btnCriaPixCom.UseVisualStyleBackColor = true;
            btnCriaPixCom.Click += btnCriaPixCom_Click;
            // 
            // btnCriaPixSem
            // 
            btnCriaPixSem.Location = new System.Drawing.Point(163, 147);
            btnCriaPixSem.Name = "btnCriaPixSem";
            btnCriaPixSem.Size = new System.Drawing.Size(151, 41);
            btnCriaPixSem.TabIndex = 8;
            btnCriaPixSem.Text = "Criar Pix Imediato\r\n(sem txid)";
            btnCriaPixSem.UseVisualStyleBackColor = true;
            btnCriaPixSem.Click += btnCriaPixSem_Click;
            // 
            // btnConsultaVarios
            // 
            btnConsultaVarios.Location = new System.Drawing.Point(163, 100);
            btnConsultaVarios.Name = "btnConsultaVarios";
            btnConsultaVarios.Size = new System.Drawing.Size(151, 41);
            btnConsultaVarios.TabIndex = 7;
            btnConsultaVarios.Text = "Consultar Varios Pix";
            btnConsultaVarios.UseVisualStyleBackColor = true;
            btnConsultaVarios.Click += btnConsultaVarios_Click;
            // 
            // btnConsultaPix
            // 
            btnConsultaPix.Location = new System.Drawing.Point(163, 53);
            btnConsultaPix.Name = "btnConsultaPix";
            btnConsultaPix.Size = new System.Drawing.Size(151, 41);
            btnConsultaPix.TabIndex = 6;
            btnConsultaPix.Text = "Consultar Pix Imediato";
            btnConsultaPix.UseVisualStyleBackColor = true;
            btnConsultaPix.Click += btnConsultaPix_Click;
            // 
            // btnAtualizaPixImediato
            // 
            btnAtualizaPixImediato.Location = new System.Drawing.Point(163, 6);
            btnAtualizaPixImediato.Name = "btnAtualizaPixImediato";
            btnAtualizaPixImediato.Size = new System.Drawing.Size(151, 41);
            btnAtualizaPixImediato.TabIndex = 5;
            btnAtualizaPixImediato.Text = "Atualizar Pix Imediato";
            btnAtualizaPixImediato.UseVisualStyleBackColor = true;
            btnAtualizaPixImediato.Click += btnAtualizaPixImediato_Click;
            // 
            // btnConsultarDevolucao
            // 
            btnConsultarDevolucao.Location = new System.Drawing.Point(6, 147);
            btnConsultarDevolucao.Name = "btnConsultarDevolucao";
            btnConsultarDevolucao.Size = new System.Drawing.Size(151, 41);
            btnConsultarDevolucao.TabIndex = 4;
            btnConsultarDevolucao.Text = "Consultar Devolucao";
            btnConsultarDevolucao.UseVisualStyleBackColor = true;
            btnConsultarDevolucao.Click += btnConsultarDevolucao_Click;
            // 
            // btnSolicitarDevolucao
            // 
            btnSolicitarDevolucao.Location = new System.Drawing.Point(6, 100);
            btnSolicitarDevolucao.Name = "btnSolicitarDevolucao";
            btnSolicitarDevolucao.Size = new System.Drawing.Size(151, 41);
            btnSolicitarDevolucao.TabIndex = 3;
            btnSolicitarDevolucao.Text = "Solicitar Devolucao";
            btnSolicitarDevolucao.UseVisualStyleBackColor = true;
            btnSolicitarDevolucao.Click += btnSolicitarDevolucao_Click;
            // 
            // btnConsultarPixRecebidos
            // 
            btnConsultarPixRecebidos.Location = new System.Drawing.Point(6, 53);
            btnConsultarPixRecebidos.Name = "btnConsultarPixRecebidos";
            btnConsultarPixRecebidos.Size = new System.Drawing.Size(151, 41);
            btnConsultarPixRecebidos.TabIndex = 2;
            btnConsultarPixRecebidos.Text = "Consultar Pix Recebidos";
            btnConsultarPixRecebidos.UseVisualStyleBackColor = true;
            btnConsultarPixRecebidos.Click += btnConsultarPixRecebidos_Click;
            // 
            // btnConsultarPix
            // 
            btnConsultarPix.Location = new System.Drawing.Point(6, 6);
            btnConsultarPix.Name = "btnConsultarPix";
            btnConsultarPix.Size = new System.Drawing.Size(151, 41);
            btnConsultarPix.TabIndex = 1;
            btnConsultarPix.Text = "Consultar Pix";
            btnConsultarPix.UseVisualStyleBackColor = true;
            btnConsultarPix.Click += btnConsultarPix_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtRetorno);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(748, 233);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "Retorno";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtRetorno
            // 
            txtRetorno.Dock = System.Windows.Forms.DockStyle.Fill;
            txtRetorno.Location = new System.Drawing.Point(3, 3);
            txtRetorno.Multiline = true;
            txtRetorno.Name = "txtRetorno";
            txtRetorno.Size = new System.Drawing.Size(742, 227);
            txtRetorno.TabIndex = 0;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Location = new System.Drawing.Point(12, 288);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(756, 261);
            tabControl2.TabIndex = 0;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(104, 4);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(46, 15);
            label22.TabIndex = 1;
            label22.Text = "clientId";
            // 
            // txtClientId
            // 
            txtClientId.Location = new System.Drawing.Point(104, 22);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new System.Drawing.Size(141, 23);
            txtClientId.TabIndex = 2;
            // 
            // txtClientSecret
            // 
            txtClientSecret.Location = new System.Drawing.Point(251, 22);
            txtClientSecret.Name = "txtClientSecret";
            txtClientSecret.Size = new System.Drawing.Size(181, 23);
            txtClientSecret.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(251, 4);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 3;
            label2.Text = "clientSecret";
            // 
            // btnInicializar
            // 
            btnInicializar.Location = new System.Drawing.Point(12, 21);
            btnInicializar.Name = "btnInicializar";
            btnInicializar.Size = new System.Drawing.Size(86, 23);
            btnInicializar.TabIndex = 5;
            btnInicializar.Text = "Inicializar";
            btnInicializar.UseVisualStyleBackColor = true;
            btnInicializar.Click += btnInicializar_Click;
            // 
            // lblOnOff
            // 
            lblOnOff.AutoSize = true;
            lblOnOff.Location = new System.Drawing.Point(12, 4);
            lblOnOff.Name = "lblOnOff";
            lblOnOff.Size = new System.Drawing.Size(28, 15);
            lblOnOff.TabIndex = 6;
            lblOnOff.Text = "OFF";
            // 
            // txtScopes
            // 
            txtScopes.Location = new System.Drawing.Point(438, 21);
            txtScopes.Name = "txtScopes";
            txtScopes.Size = new System.Drawing.Size(326, 23);
            txtScopes.TabIndex = 8;
            txtScopes.Text = "boleto-cobranca.read boleto-cobranca.write cob.write cob.read";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(438, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 15);
            label1.TabIndex = 7;
            label1.Text = "scopes";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(txtScopes);
            Controls.Add(label1);
            Controls.Add(lblOnOff);
            Controls.Add(btnInicializar);
            Controls.Add(txtClientSecret);
            Controls.Add(label2);
            Controls.Add(txtClientId);
            Controls.Add(label22);
            Controls.Add(tabControl2);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabControl2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.Button btnCriarBoleto;
        private System.Windows.Forms.Button btnBuscarBoleto;
        private System.Windows.Forms.Button btnBuscarSumario;
        private System.Windows.Forms.Button btnBuscarVariosBoletos;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInicializar;
        private System.Windows.Forms.Label lblOnOff;
        private System.Windows.Forms.TextBox txtScopes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelaBoleto;
        private System.Windows.Forms.Button btnGeraboleto;
        private System.Windows.Forms.TextBox txtRetorno;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnConsultarDevolucao;
        private System.Windows.Forms.Button btnSolicitarDevolucao;
        private System.Windows.Forms.Button btnConsultarPixRecebidos;
        private System.Windows.Forms.Button btnConsultarPix;
        private System.Windows.Forms.Button btnCriaPixSem;
        private System.Windows.Forms.Button btnConsultaVarios;
        private System.Windows.Forms.Button btnConsultaPix;
        private System.Windows.Forms.Button btnAtualizaPixImediato;
        private System.Windows.Forms.Button btnCriaPixCom;
        private System.Windows.Forms.Button btnPixVencimentoBuscar;
        private System.Windows.Forms.Button btPixVencimentoBuscarUm;
        private System.Windows.Forms.Button btnPixVencimentoAtualizar;
        private System.Windows.Forms.Button btnCriarPixVencimento;
    }
}
