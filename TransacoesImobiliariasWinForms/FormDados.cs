using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransacoesImobiliariasWinForms
{
    public partial class FormDados : Form
    {

        public FormDados()
        {

            InitializeComponent();
            
        }

        public void EncherLista<T>(List<T> list)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = list;
        }

        private void FormDados_Load(object sender, EventArgs e)
        {
            
        }
    }
}
