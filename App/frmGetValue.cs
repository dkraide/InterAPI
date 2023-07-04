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
    public partial class frmGetValue : Form
    {
        public frmGetValue(string title, string messsage)
        {
            InitializeComponent();
            this.Text = title;
            this.txtMessage.Text = messsage;

        }
        public string Value = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Value = txtValue.Text;
            this.DialogResult= DialogResult.OK;
            this.Close();

        }
    }
}
