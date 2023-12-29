using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoTransacoesImobiliarias.Models;


namespace TransacoesImobiliariasWinForms
{
    public partial class UserForm : Form
    {
        private string message = "Bem-vindo ";
        public FormsController _formController;

        public UserForm(User user)
        {
            this.Text = message + user.Name;
            InitializeComponent();
            _formController = new FormsController();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (MenuPanel.Size.Width == 152)
            {
                MoverMenuDiminuir();
            }
            else
            {
                MoverMenuAumentar();
            }


        }

        private void MoverMenuAumentar()
        {

            MenuPanel.Size = new Size(152, 523);
            buttonGerirClientes.Visible = true;
            buttonGerirPropriedades.Visible = true;
            buttonGerirUsers.Visible = true;
        }
        private void MoverMenuDiminuir()
        {
            MenuPanel.Size = new Size(45, 523);
            buttonGerirClientes.Visible = false;
            buttonGerirPropriedades.Visible = false;
            buttonGerirUsers.Visible = false;
        }

        private void totalFuncionarios_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(totalFuncionarios.Text))
            {
                if (int.TryParse(totalFuncionarios.Text, out int value))
                {
                    // Certifique-se de que o valor está dentro dos limites da barra de progresso
                    value = Math.Max(progressBarTotalFuncionarios.Minimum, Math.Min(value, progressBarTotalFuncionarios.Maximum));

                    progressBarTotalFuncionarios.Value = value;
                }
                else
                {
                    totalFuncionarios.Text = string.Empty; // ou outra lógica de tratamento
                }
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

            UpdateForm();


        }

        private void UpdateForm()
        {

            //carregar dados aqui
            totalFuncionarios.Text = _formController.TotalFuncionariosSQL().ToString();
            totalClientesLabel.Text = _formController.TotalClientesSQL();
            totalProVendaLabel.Text = _formController.TotalProVendaSQL();
            proVendaMesLabel.Text = _formController.TotalProVendidasMesSQL();
            clientesPropostasLabel.Text = _formController.ClintePropEfetuadaSQL();
            clientesFaltaPagLabel.Text = _formController.ClienteFaltaPagamentoSQL();
            funcionarioMesLLabel.Text = _formController.FuncionariosMesSQL();

        }

        #region Fazer pedidos SQL



        #endregion

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void totalFuncionariosLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void totalClientesLabel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(totalClientesLabel.Text))
            {
                if (int.TryParse(totalClientesLabel.Text, out int value))
                {
                    // Certifique-se de que o valor está dentro dos limites da barra de progresso
                    value = Math.Max(progressBarTotalCliente.Minimum, Math.Min(value, progressBarTotalCliente.Maximum));

                    progressBarTotalCliente.Value = value;
                }
                else
                {

                    totalClientesLabel.Text = string.Empty; // ou outra lógica de tratamento
                }
            }
        }

        private void totalProVendaLabel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(totalProVendaLabel.Text))
            {
                if (int.TryParse(totalProVendaLabel.Text, out int value))
                {
                    // Certifique-se de que o valor está dentro dos limites da barra de progresso
                    value = Math.Max(progressBarTotalVendas.Minimum, Math.Min(value, progressBarTotalVendas.Maximum));

                    progressBarTotalVendas.Value = value;
                }
                else
                {
                    totalProVendaLabel.Text = string.Empty; // ou outra lógica de tratamento
                }
            }
        }

        private void clientesPropostasLabel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(clientesPropostasLabel.Text))
            {
                if (int.TryParse(clientesPropostasLabel.Text, out int value))
                {
                    // Certifique-se de que o valor está dentro dos limites da barra de progresso
                    value = Math.Max(progressBarClienteProposta.Minimum, Math.Min(value, progressBarClienteProposta.Maximum));

                    progressBarClienteProposta.Value = value;
                }
                else
                {
                    clientesPropostasLabel.Text = string.Empty; // ou outra lógica de tratamento
                }
            }
        }

        private void clientesFaltaPagLabel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(clientesFaltaPagLabel.Text))
            {
                if (int.TryParse(clientesFaltaPagLabel.Text, out int value))
                {
                    // Certifique-se de que o valor está dentro dos limites da barra de progresso
                    value = Math.Max(progressBarFaltaPag.Minimum, Math.Min(value, progressBarFaltaPag.Maximum));

                    progressBarFaltaPag.Value = value;
                }
                else
                {
                    clientesFaltaPagLabel.Text = string.Empty; // ou outra lógica de tratamento
                }
            }
        }

        private void proVendaMesLabel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(proVendaMesLabel.Text))
            {
                if (int.TryParse(proVendaMesLabel.Text, out int value))
                {
                    // Certifique-se de que o valor está dentro dos limites da barra de progresso
                    value = Math.Max(progressBarProVendidas.Minimum, Math.Min(value, progressBarProVendidas.Maximum));

                    progressBarProVendidas.Value = value;
                }
                else
                {
                    proVendaMesLabel.Text = string.Empty; // ou outra lógica de tratamento
                }
            }
        }

        private void buttonGerirUsers_Click(object sender, EventArgs e)
        {
            GerirClientes a = new GerirClientes();
            a.Show();
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void UserForm_Activated(object sender, EventArgs e)
        {
            UpdateForm();
        }
    }
}
