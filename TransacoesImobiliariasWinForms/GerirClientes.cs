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
        public GerirClientes()
        {
            InitializeComponent();
        }

        private void GerirClientes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Client> list = new List<Client>();



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

            listBox1.Visible = true;
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
            }

            //Completa o form com dados


            listBox1.Visible = false;

        }
    }
}
