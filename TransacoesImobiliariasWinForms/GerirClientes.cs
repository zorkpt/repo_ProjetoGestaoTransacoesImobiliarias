using ProjetoTransacoesImobiliarias.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TransacoesImobiliariasWinForms.DefForms;


namespace TransacoesImobiliariasWinForms
{
    public partial class GerirClientes : Form
    {

        public FormsController _formController;

        public GerirClientes()
        {
            InitializeComponent();
            _formController = new FormsController();


        }

        private void GerirClientes_Load(object sender, EventArgs e)
        {
            List<string> list = _formController.TipoContactoSQL();
            comboBox1.DataSource = list; comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Dados _dados = new Dados();
            List<Client> list = _dados.TodosClientes();

            FormDados f = new FormDados();
            f.EncherLista(list);
            f.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string userInput = textBox2.Text;
            if (userInput == "")
            {
                listBox1.Items.Clear();
                listBox1.Visible = false;
                return;
            }
            Dados _dados = new Dados();

            //SQL
            List<Client> list = new List<Client>();
            list = _dados.ProcSqlByNif(userInput);



            // Update the suggestions list
            AtualizarListBox(list);

            //listBox1.Visible = true;
            listBox1.Visible = listBox1.Items.Count > 0;
        }

        private void AtualizarListBox(List<Client> list)
        {
            listBox1.Items.Clear();
            foreach (Client client in list)
            {
                //listBox1.Items.Add(client);
                listBox1.Items.Add($"Nome: {client.Name}, NIF: {client.NIF}");

            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Get the selected item
                string selectedItem = listBox1.SelectedItem.ToString();
                string[] a = selectedItem.Split(",");
                string[] nome = a[0].Split(":");
                string[] nif = a[1].Split(":");

                // Do something with the selected item
                textBox2.Text = nif[1];

                FormsController formsController = new FormsController();
                AtualizaCamposCliente(nif[1].ToString());
            }

            //Completa o form com dados


            listBox1.Visible = false;



        }

        private void AtualizaCamposCliente(string nif)
        {
            Dados _dados = new Dados();
            Client cliente = _dados.ProcClientSqlByNif(nif);
            if (cliente != null)
            {
                CamposGereCliente(cliente);
            }
        }

        private void CamposGereCliente(Client cliente)
        {
            textBox1.Text = cliente.Name;
            textBox3.Text = cliente.CC;
            dateTimePicker1.Text = cliente.DateOfBirth;
            textBox5.Text = cliente.Address;
            textBox6.Text = cliente.Contact.Descricao;
        }




        /// <summary>
        /// Adicionar clientes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGerirUsers_Click(object sender, EventArgs e)
        {
            Dados _dados = new Dados();
            FormsController _formsController = new FormsController();
            string? nome = textBox1.Text;
            string? nif = textBox2.Text;
            string? cc = textBox3.Text;
            //string? data = dateTimePicker1.Text;

            DateTime data = dateTimePicker1.Checked ? dateTimePicker1.Value : DateTime.MinValue;

            string? morada = textBox5.Text;
            string? contacto = textBox6.Text;
            string? tipoContacto = comboBox1.Text;

            //verificar se dados estao preenchidos 
            if (!VerificaCamposCliente()) return;
            // Verificar se o nif ja existe
            if (_dados.ExisteNif(textBox2.Text))
            {
                MessageBox.Show("Cliente ja existe");
                return;
            }

            //inserir na base de dados 
            if (data != null)
            {
                if (_formsController.InserirClienteSQL(nome, nif, data, contacto, cc, morada, tipoContacto))
                {
                    MessageBox.Show("Cliente inserido com sucesso.");
                }
            }
            //informar user que os dados foram inseridos com sucesso 

            //limpar form


        }

        #region Gestao de form
        private bool LimparForm()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            return true;
        }

        private bool VerificaCamposCliente()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return false;
            }

            return true;
        }

        #endregion

        private void listBox1_DataSourceChanged(object sender, EventArgs e)
        {
            listBox1.Visible = listBox1.Items.Count > 0;
        }
    }
}
