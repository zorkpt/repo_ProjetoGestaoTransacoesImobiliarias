namespace TransacoesImobiliariasWinForms
{
    partial class GerirClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MenuPanel = new Panel();
            LimparCampos = new Button();
            button6 = new Button();
            panel1 = new Panel();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button1 = new Button();
            ButtonpagarCliente = new Button();
            buttonGerirClientes = new Button();
            buttonGerirUsers = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            panel8 = new Panel();
            listBox1 = new ListBox();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            comboBox1 = new ComboBox();
            MenuPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPanel
            // 
            MenuPanel.BackColor = Color.GhostWhite;
            MenuPanel.Controls.Add(LimparCampos);
            MenuPanel.Controls.Add(button6);
            MenuPanel.Controls.Add(panel1);
            MenuPanel.Controls.Add(button1);
            MenuPanel.Controls.Add(ButtonpagarCliente);
            MenuPanel.Controls.Add(buttonGerirClientes);
            MenuPanel.Controls.Add(buttonGerirUsers);
            MenuPanel.Location = new Point(0, 52);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(166, 433);
            MenuPanel.TabIndex = 1;
            // 
            // LimparCampos
            // 
            LimparCampos.Location = new Point(12, 222);
            LimparCampos.Name = "LimparCampos";
            LimparCampos.Size = new Size(121, 23);
            LimparCampos.TabIndex = 14;
            LimparCampos.Text = "Limpar Campos";
            LimparCampos.UseVisualStyleBackColor = true;
            LimparCampos.Click += LimparCampos_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(12, 149);
            button6.Name = "button6";
            button6.Size = new Size(123, 52);
            button6.TabIndex = 13;
            button6.Text = "Ver lista de clientes";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button5);
            panel1.Location = new Point(172, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(781, 113);
            panel1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(12, 365);
            button2.Name = "button2";
            button2.Size = new Size(121, 33);
            button2.TabIndex = 3;
            button2.Text = "Voltar";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(10, 190);
            button3.Name = "button3";
            button3.Size = new Size(121, 33);
            button3.TabIndex = 2;
            button3.Text = "Apagar Cliente";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F);
            button4.Location = new Point(10, 151);
            button4.Name = "button4";
            button4.Size = new Size(121, 33);
            button4.TabIndex = 1;
            button4.Text = "Atualizar Cliente";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(10, 112);
            button5.Name = "button5";
            button5.Size = new Size(121, 33);
            button5.TabIndex = 0;
            button5.Text = "Adicionar cliente";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(12, 309);
            button1.Name = "button1";
            button1.Size = new Size(121, 33);
            button1.TabIndex = 14;
            button1.Text = "Voltar";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // ButtonpagarCliente
            // 
            ButtonpagarCliente.Font = new Font("Segoe UI", 12F);
            ButtonpagarCliente.Location = new Point(12, 94);
            ButtonpagarCliente.Name = "ButtonpagarCliente";
            ButtonpagarCliente.Size = new Size(121, 33);
            ButtonpagarCliente.TabIndex = 12;
            ButtonpagarCliente.Text = "Apagar Cliente";
            ButtonpagarCliente.UseVisualStyleBackColor = true;
            ButtonpagarCliente.Click += buttonGerirPropriedades_Click;
            // 
            // buttonGerirClientes
            // 
            buttonGerirClientes.Font = new Font("Segoe UI", 12F);
            buttonGerirClientes.Location = new Point(12, 55);
            buttonGerirClientes.Name = "buttonGerirClientes";
            buttonGerirClientes.Size = new Size(121, 33);
            buttonGerirClientes.TabIndex = 11;
            buttonGerirClientes.Text = "Atualizar Cliente";
            buttonGerirClientes.UseVisualStyleBackColor = true;
            buttonGerirClientes.Click += buttonGerirClientes_Click;
            // 
            // buttonGerirUsers
            // 
            buttonGerirUsers.Font = new Font("Segoe UI", 12F);
            buttonGerirUsers.Location = new Point(12, 16);
            buttonGerirUsers.Name = "buttonGerirUsers";
            buttonGerirUsers.Size = new Size(121, 33);
            buttonGerirUsers.TabIndex = 10;
            buttonGerirUsers.Text = "Adicionar cliente";
            buttonGerirUsers.UseVisualStyleBackColor = true;
            buttonGerirUsers.Click += buttonGerirUsers_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(210, 125);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(210, 79);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 3;
            label2.Text = "NIF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(210, 176);
            label3.Name = "label3";
            label3.Size = new Size(27, 20);
            label3.TabIndex = 4;
            label3.Text = "CC";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(210, 221);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 5;
            label4.Text = "Data de nascimento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(210, 273);
            label5.Name = "label5";
            label5.Size = new Size(34, 20);
            label5.TabIndex = 6;
            label5.Text = "Rua";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(210, 324);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 7;
            label6.Text = "Contacto";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(380, 126);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(397, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(380, 80);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(397, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.KeyPress += textBox2_KeyPress;
            textBox2.Leave += textBox2_Leave;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(380, 174);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(397, 23);
            textBox3.TabIndex = 3;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(380, 274);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(397, 23);
            textBox5.TabIndex = 5;
            textBox5.KeyPress += textBox5_KeyPress;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(380, 325);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(295, 23);
            textBox6.TabIndex = 6;
            textBox6.KeyPress += textBox6_KeyPress;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(380, 220);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(397, 23);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.KeyPress += dateTimePicker1_KeyPress;
            // 
            // panel8
            // 
            panel8.BackColor = Color.LightSteelBlue;
            panel8.Location = new Point(-24, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(912, 54);
            panel8.TabIndex = 15;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(452, 98);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(397, 199);
            listBox1.TabIndex = 16;
            listBox1.Visible = false;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.DataSourceChanged += listBox1_DataSourceChanged;
            listBox1.SelectedValueChanged += listBox1_SelectedValueChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(669, 370);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(108, 15);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Todos os contactos";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(636, 351);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(141, 15);
            linkLabel2.TabIndex = 8;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Adicionar mais contactos";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.ImeMode = ImeMode.NoControl;
            comboBox1.ItemHeight = 15;
            comboBox1.Location = new Point(681, 325);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(96, 23);
            comboBox1.TabIndex = 7;
            // 
            // GerirClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(881, 414);
            Controls.Add(comboBox1);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(listBox1);
            Controls.Add(MenuPanel);
            Controls.Add(panel8);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            KeyPreview = true;
            MaximizeBox = false;
            Name = "GerirClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GerirClientes";
            FormClosed += GerirClientes_FormClosed;
            Load += GerirClientes_Load;
            MenuPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel MenuPanel;
        private Button ButtonpagarCliente;
        private Button buttonGerirClientes;
        private Button buttonGerirUsers;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button6;
        private DateTimePicker dateTimePicker1;
        private Panel panel8;
        private ListBox listBox1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private ComboBox comboBox1;
        private Button LimparCampos;
    }
}