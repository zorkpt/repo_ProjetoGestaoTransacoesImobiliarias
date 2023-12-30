using ProjetoTransacoesImobiliarias.Models;
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
    public partial class FormPropriedades : Form
    {
        public FormsController _formController;
        private User utilizador {  get; set; }
        public FormPropriedades()
        {
            InitializeComponent();
            _formController = new FormsController();
        }

        public FormPropriedades(User user)
        {
            InitializeComponent();
            _formController = new FormsController();
            utilizador = user;
        }

        private void ListaPropriedades_Click(object sender, EventArgs e)
        {
            List<Property> list = _formController.CriaListaPropriedades();

            if(list.Count <= 0) 
            {
                MessageBox.Show("Não existem dados");
                return;
            }

            FormDados f = new FormDados();
            f.EncherLista(list);
            f.Show();
        }
    }
}
