using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransacoesImobiliariasWinForms.DefForms
{
    internal class GerirForms
    {

        public GerirForms() { }
        public void CriaLayout(Form f)
        {
            Label labelCabecalho = new Label();
            Label labelLateral = new Label();
            BarraCabecalho(f, labelCabecalho);
            
                
            f.Controls.Add(labelCabecalho);
        }
        public void BarraCabecalho(Form f, Label label)
        {
            // Criar uma nova instância de Label
            //Label label = new Label();

            // Configurar propriedades da label
            label.Text = "Texto da Label";
            label.BackColor = Color.LightSteelBlue;
            label.Size = new Size(888, 54);
            label.Location = new Point(2, 1);
            // Definir a localização da label (posição no formulário)
            label.Location = new System.Drawing.Point(10, 10); // X = 10, Y = 10

            // Adicionar a label ao controle do formulário
            f.Controls.Add(label);
        }
    }
}
