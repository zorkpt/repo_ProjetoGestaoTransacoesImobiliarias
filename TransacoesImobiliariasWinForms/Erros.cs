using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TransacoesImobiliariasWinForms
{
    public partial class Erros : Form
    {
        public Erros(string texto)
        {
            InitializeComponent();
            textErros.Text = texto;
        }


    }
}
