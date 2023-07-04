using InterAPI.Model;
using InterAPI.Model.FBoleto;
using InterAPI.ModelRequest;
using InterAPI.Service;
using InterAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInicializar_Click(object sender, EventArgs e)
        {
            var res = Helpers.GetCert();
            var frm = new frmGetValue("Selecionar Senha", "Informe a Senha do Certificado");
            frm.ShowDialog();
            SOAuth.SetCertificate(res, frm.Value);
            var ret = SOAuth.SetToken(txtClientId.Text, txtClientSecret.Text, txtScopes.Text);
            lblOnOff.Text = "ON";
            btnInicializar.Enabled = false;
            if (!ret)
            {
                MessageBox.Show("Erro ao inicializar");
            }
        }

        #region boletos
        private void btnBuscarVariosBoletos_Click(object sender, EventArgs e)
        {
            var res = SBoletos.GetBoletos(Helpers.GetParametros(), null);
            SetRetorno(res);
        }
        void SetRetorno(object obj)
        {
            txtRetorno.Text = JsonConvert.SerializeObject(obj);
        }
        private void btnBuscarBoleto_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Nosso Numero", "Informe o Nosso Numero");
            get.ShowDialog();
            var res = SBoletos.GetBoleto(get.Value, null);
            SetRetorno(res);
        }

        private void btnBuscarSumario_Click(object sender, EventArgs e)
        {
            var res = SBoletos.GetSumario(Helpers.GetParametros(), null);
            SetRetorno(res);
        }

        private void btnCriarBoleto_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Nosso Numero", "Informe um Nosso Numero");
            get.ShowDialog();
            Boleto x = new Boleto
            {
                seuNumero = get.Value,
                valorNominal = 100,
                valorAbatimento = 0,
                dataVencimento = DateTime.Now.AddDays(1),
                numDiasAgenda = 60,
                pagador = new Pagador
                {
                    cpfCnpj = "34073667000136",
                    tipoPessoa = "JURIDICA",
                    nome = "DANIEL AUGUSTO KRAIDE",
                    endereco = "rua 1",
                    cidade = "PIRACICABA",
                    uf = "SP",
                    cep = "13421282",
                },
                multa = new Multa
                {
                    codigoMulta = "PERCENTUAL",
                    data = DateTime.Now.AddDays(1),
                    taxa = 2,
                    valor = 0
                },
                mora = new Mora()
                {
                    codigoMora = "VALORDIA",
                    data = DateTime.Now.AddDays(1),
                    valor = 0.2m,
                    taxa = 0
                }
            };
            var res = SBoletos.CreateBoleto(x, null);
            SetRetorno(res);
        }

        private void btnGeraboleto_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Nosso Numero", "Informe um Nosso Numero");
            get.ShowDialog();
            var res = SBoletos.GetBoletoPDF(get.Value, null);
            SetRetorno(res);
        }

        private void btnCancelaBoleto_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Nosso Numero", "Informe um Nosso Numero");
            get.ShowDialog();
            var res = SBoletos.CancelarBoleto("APEDIDODOCLIENTE", get.Value, null);
            SetRetorno(res);
        }
        #endregion

        #region pix
        private void btnConsultarPix_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Informe o valor e2eid", "Informe o valor e2eid");
            get.ShowDialog();
            var res = SPix.ConsultarPix(get.Value, null);
            SetRetorno(res);
        }

        private void btnConsultarPixRecebidos_Click(object sender, EventArgs e)
        {
            var res = SPix.ConsultarPixRecebidos(Helpers.PixGetParametro(), null);
            SetRetorno(res);
        }

        private void btnSolicitarDevolucao_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Informe o valor e2eid", "Informe o valor e2eid");
            get.ShowDialog();
            frmGetValue getId = new frmGetValue("Informe o valor id", "Informe o valor id");
            getId.ShowDialog();
            PixSolicitaDevolucaoRequest req = new PixSolicitaDevolucaoRequest
            {
                descricao = "pix mandado errado",
                e2eId = get.Value,
                id = getId.Value,
                natureza = "ORIGINAL",
                valor = "10.0"
            };
            var res = SPix.SolicitarDevolucao(req, null);
            SetRetorno(res);
        }

        private void btnConsultarDevolucao_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Informe o valor e2eid", "Informe o valor e2eid");
            get.ShowDialog();

            frmGetValue getId = new frmGetValue("Informe o valor id", "Informe o valor id");
            getId.ShowDialog();

            var res = SPix.ConsultarDevolucao(get.Value, getId.Value, null);
            SetRetorno(res);
        }


        private void btnCriaPixCom_Click(object sender, EventArgs e)
        {
            //PREENCHA O GET PIX PRA FUNCIONAR
            var res = SPixImediato.Put(Helpers.GetPix(), null);
            SetRetorno(res);
        }
        private void btnCriaPixSem_Click(object sender, EventArgs e)
        {
            //PREENCHA O GET PIX PRA FUNCIONAR
            var res = SPixImediato.Post(Helpers.GetPix(), null);
            SetRetorno(res);
        }
        private void btnConsultaVarios_Click(object sender, EventArgs e)
        {
            var res = SPixImediato.Get(Helpers.PixGetParametro(), null);
            SetRetorno(res);
        }
        private void btnConsultaPix_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Informe o txid", "Informe o txid do Pix");
            get.ShowDialog();
            var res = SPixImediato.Get(get.Value);
            SetRetorno(res);
        }
        private void btnAtualizaPixImediato_Click(object sender, EventArgs e)
        {
            //PREENCHA O GET PIX PRA FUNCIONAR
            var res = SPixImediato.Patch(Helpers.GetPix(), null);
            SetRetorno(res);
        }
        private void btnCriarPixVencimento_Click(object sender, EventArgs e)
        {
            //Preencha o obj pixvencimento com seus dados
            frmGetValue get = new frmGetValue("Informe o txid", "Informe o txid do Pix");
            get.ShowDialog();
            var res = SPixVencimento.Put(Helpers.GetPixVencimento(get.Value), null);
            SetRetorno(res);
        }
        private void btnPixVencimentoAtualizar_Click(object sender, EventArgs e)
        {
            //Preencha o obj pixvencimento com seus dados
            frmGetValue get = new frmGetValue("Informe o txid", "Informe o txid do Pix");
            get.ShowDialog();
            var res = SPixVencimento.Patch(Helpers.GetPixVencimento(get.Value), null);
            SetRetorno(res);
        }
        private void btPixVencimentoBuscarUm_Click(object sender, EventArgs e)
        {
            frmGetValue get = new frmGetValue("Informe o txid", "Informe o txid do Pix");
            get.ShowDialog();
            var res = SPixVencimento.Get(get.Value, null);
            SetRetorno(res);
        }
        private void btnPixVencimentoBuscar_Click(object sender, EventArgs e)
        {
            var res = SPixVencimento.Get(Helpers.PixGetParametro(), null);
            SetRetorno(res);
        }

        #endregion

    }
}
