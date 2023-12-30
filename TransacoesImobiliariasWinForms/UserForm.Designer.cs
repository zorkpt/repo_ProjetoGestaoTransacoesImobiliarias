namespace TransacoesImobiliariasWinForms
{
    partial class UserForm
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
            iconButton3 = new FontAwesome.Sharp.IconButton();
            buttonGerirPropriedades = new Button();
            buttonGerirClientes = new Button();
            buttonGerirUsers = new Button();
            panel2 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel12 = new Panel();
            panel11 = new Panel();
            progressBarTotalFuncionarios = new ProgressBar();
            LocVendasLabel = new Label();
            label15 = new Label();
            funcionarioMesLLabel = new Label();
            label17 = new Label();
            totalFuncionarios = new Label();
            label19 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            progressBarFaltaPag = new ProgressBar();
            progressBarClienteProposta = new ProgressBar();
            panel10 = new Panel();
            progressBarTotalCliente = new ProgressBar();
            clientesFaltaPagLabel = new Label();
            label12 = new Label();
            clientesPropostasLabel = new Label();
            label10 = new Label();
            totalClientesLabel = new Label();
            label8 = new Label();
            panel5 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            panel14 = new Panel();
            progressBarProVendidas = new ProgressBar();
            panel13 = new Panel();
            progressBarTotalVendas = new ProgressBar();
            proVendaMesLabel = new Label();
            label6 = new Label();
            totalProVendaLabel = new Label();
            label4 = new Label();
            panel7 = new Panel();
            label3 = new Label();
            panel8 = new Panel();
            panel9 = new Panel();
            button1 = new Button();
            MenuPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPanel
            // 
            MenuPanel.BackColor = Color.GhostWhite;
            MenuPanel.Controls.Add(button1);
            MenuPanel.Controls.Add(iconButton3);
            MenuPanel.Controls.Add(buttonGerirPropriedades);
            MenuPanel.Controls.Add(buttonGerirClientes);
            MenuPanel.Controls.Add(buttonGerirUsers);
            MenuPanel.Location = new Point(2, -2);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(45, 523);
            MenuPanel.TabIndex = 0;
            // 
            // iconButton3
            // 
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI", 5.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.AlignJustify;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 20;
            iconButton3.Location = new Point(10, 63);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(26, 29);
            iconButton3.TabIndex = 28;
            iconButton3.TextAlign = ContentAlignment.BottomLeft;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // buttonGerirPropriedades
            // 
            buttonGerirPropriedades.Location = new Point(10, 200);
            buttonGerirPropriedades.Name = "buttonGerirPropriedades";
            buttonGerirPropriedades.Size = new Size(121, 33);
            buttonGerirPropriedades.TabIndex = 2;
            buttonGerirPropriedades.Text = "Propriedades";
            buttonGerirPropriedades.UseVisualStyleBackColor = true;
            buttonGerirPropriedades.Visible = false;
            buttonGerirPropriedades.Click += buttonGerirPropriedades_Click;
            // 
            // buttonGerirClientes
            // 
            buttonGerirClientes.Location = new Point(10, 151);
            buttonGerirClientes.Name = "buttonGerirClientes";
            buttonGerirClientes.Size = new Size(121, 33);
            buttonGerirClientes.TabIndex = 1;
            buttonGerirClientes.Text = "Gerir Users";
            buttonGerirClientes.UseVisualStyleBackColor = true;
            buttonGerirClientes.Visible = false;
            // 
            // buttonGerirUsers
            // 
            buttonGerirUsers.Location = new Point(10, 112);
            buttonGerirUsers.Name = "buttonGerirUsers";
            buttonGerirUsers.Size = new Size(121, 33);
            buttonGerirUsers.TabIndex = 0;
            buttonGerirUsers.Text = "Gerir Clientes";
            buttonGerirUsers.UseVisualStyleBackColor = true;
            buttonGerirUsers.Visible = false;
            buttonGerirUsers.Click += buttonGerirUsers_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(iconButton2);
            panel2.Controls.Add(iconButton1);
            panel2.Controls.Add(panel12);
            panel2.Controls.Add(panel11);
            panel2.Controls.Add(progressBarTotalFuncionarios);
            panel2.Controls.Add(LocVendasLabel);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(funcionarioMesLLabel);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(totalFuncionarios);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(179, 79);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 310);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // iconButton2
            // 
            iconButton2.BackgroundImageLayout = ImageLayout.Zoom;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(124, 251);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(48, 53);
            iconButton2.TabIndex = 28;
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserNinja;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(124, 151);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(48, 53);
            iconButton1.TabIndex = 27;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // panel12
            // 
            panel12.BorderStyle = BorderStyle.Fixed3D;
            panel12.Location = new Point(0, 113);
            panel12.Name = "panel12";
            panel12.Size = new Size(199, 10);
            panel12.TabIndex = 26;
            // 
            // panel11
            // 
            panel11.BorderStyle = BorderStyle.Fixed3D;
            panel11.Location = new Point(0, 210);
            panel11.Name = "panel11";
            panel11.Size = new Size(207, 10);
            panel11.TabIndex = 23;
            // 
            // progressBarTotalFuncionarios
            // 
            progressBarTotalFuncionarios.BackColor = SystemColors.Window;
            progressBarTotalFuncionarios.ForeColor = SystemColors.GrayText;
            progressBarTotalFuncionarios.Location = new Point(13, 89);
            progressBarTotalFuncionarios.Name = "progressBarTotalFuncionarios";
            progressBarTotalFuncionarios.Size = new Size(164, 18);
            progressBarTotalFuncionarios.Step = 1;
            progressBarTotalFuncionarios.Style = ProgressBarStyle.Continuous;
            progressBarTotalFuncionarios.TabIndex = 22;
            progressBarTotalFuncionarios.Value = 80;
            // 
            // LocVendasLabel
            // 
            LocVendasLabel.AutoSize = true;
            LocVendasLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LocVendasLabel.Location = new Point(13, 248);
            LocVendasLabel.Name = "LocVendasLabel";
            LocVendasLabel.Size = new Size(40, 32);
            LocVendasLabel.TabIndex = 21;
            LocVendasLabel.Text = "15";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(13, 233);
            label15.Name = "label15";
            label15.Size = new Size(159, 15);
            label15.TabIndex = 20;
            label15.Text = "Localidade com mais vendas";
            // 
            // funcionarioMesLLabel
            // 
            funcionarioMesLLabel.AutoSize = true;
            funcionarioMesLLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            funcionarioMesLLabel.Location = new Point(13, 165);
            funcionarioMesLLabel.Name = "funcionarioMesLLabel";
            funcionarioMesLLabel.Size = new Size(74, 21);
            funcionarioMesLLabel.TabIndex = 19;
            funcionarioMesLLabel.Text = "Ze Manel";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(13, 136);
            label17.Name = "label17";
            label17.Size = new Size(165, 15);
            label17.TabIndex = 18;
            label17.Text = "Funcionario com mais vendas";
            // 
            // totalFuncionarios
            // 
            totalFuncionarios.AutoSize = true;
            totalFuncionarios.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totalFuncionarios.Location = new Point(13, 54);
            totalFuncionarios.Name = "totalFuncionarios";
            totalFuncionarios.Size = new Size(40, 32);
            totalFuncionarios.TabIndex = 17;
            totalFuncionarios.Text = "15";
            totalFuncionarios.TextChanged += totalFuncionarios_TextChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(13, 39);
            label19.Name = "label19";
            label19.Size = new Size(117, 15);
            label19.TabIndex = 16;
            label19.Text = "Total de funcionarios";
            // 
            // panel3
            // 
            panel3.BackColor = Color.GhostWhite;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 29);
            panel3.TabIndex = 4;
            panel3.Paint += panel3_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 8);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 0;
            label1.Text = "Utilizadores";
            label1.Click += label1_Click;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(progressBarFaltaPag);
            panel4.Controls.Add(progressBarClienteProposta);
            panel4.Controls.Add(panel10);
            panel4.Controls.Add(progressBarTotalCliente);
            panel4.Controls.Add(clientesFaltaPagLabel);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(clientesPropostasLabel);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(totalClientesLabel);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(409, 79);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 310);
            panel4.TabIndex = 5;
            panel4.Paint += panel4_Paint;
            // 
            // progressBarFaltaPag
            // 
            progressBarFaltaPag.ForeColor = SystemColors.GrayText;
            progressBarFaltaPag.Location = new Point(15, 283);
            progressBarFaltaPag.Name = "progressBarFaltaPag";
            progressBarFaltaPag.Size = new Size(164, 18);
            progressBarFaltaPag.Step = 1;
            progressBarFaltaPag.Style = ProgressBarStyle.Continuous;
            progressBarFaltaPag.TabIndex = 15;
            progressBarFaltaPag.Value = 75;
            // 
            // progressBarClienteProposta
            // 
            progressBarClienteProposta.ForeColor = SystemColors.GrayText;
            progressBarClienteProposta.Location = new Point(15, 186);
            progressBarClienteProposta.Name = "progressBarClienteProposta";
            progressBarClienteProposta.Size = new Size(164, 18);
            progressBarClienteProposta.Step = 1;
            progressBarClienteProposta.Style = ProgressBarStyle.Continuous;
            progressBarClienteProposta.TabIndex = 14;
            progressBarClienteProposta.Value = 50;
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.Fixed3D;
            panel10.Location = new Point(0, 210);
            panel10.Name = "panel10";
            panel10.Size = new Size(207, 10);
            panel10.TabIndex = 13;
            // 
            // progressBarTotalCliente
            // 
            progressBarTotalCliente.ForeColor = SystemColors.GrayText;
            progressBarTotalCliente.Location = new Point(15, 89);
            progressBarTotalCliente.Name = "progressBarTotalCliente";
            progressBarTotalCliente.Size = new Size(164, 18);
            progressBarTotalCliente.Step = 1;
            progressBarTotalCliente.Style = ProgressBarStyle.Continuous;
            progressBarTotalCliente.TabIndex = 11;
            progressBarTotalCliente.Value = 30;
            // 
            // clientesFaltaPagLabel
            // 
            clientesFaltaPagLabel.AutoSize = true;
            clientesFaltaPagLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clientesFaltaPagLabel.Location = new Point(15, 248);
            clientesFaltaPagLabel.Name = "clientesFaltaPagLabel";
            clientesFaltaPagLabel.Size = new Size(40, 32);
            clientesFaltaPagLabel.TabIndex = 10;
            clientesFaltaPagLabel.Text = "15";
            clientesFaltaPagLabel.TextChanged += clientesFaltaPagLabel_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(15, 233);
            label12.Name = "label12";
            label12.Size = new Size(112, 15);
            label12.TabIndex = 9;
            label12.Text = "Falta de pagamento";
            // 
            // clientesPropostasLabel
            // 
            clientesPropostasLabel.AutoSize = true;
            clientesPropostasLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clientesPropostasLabel.Location = new Point(15, 151);
            clientesPropostasLabel.Name = "clientesPropostasLabel";
            clientesPropostasLabel.Size = new Size(27, 32);
            clientesPropostasLabel.TabIndex = 8;
            clientesPropostasLabel.Text = "3";
            clientesPropostasLabel.TextChanged += clientesPropostasLabel_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(15, 136);
            label10.Name = "label10";
            label10.Size = new Size(131, 15);
            label10.TabIndex = 7;
            label10.Text = "Clientes com propostas";
            // 
            // totalClientesLabel
            // 
            totalClientesLabel.AutoSize = true;
            totalClientesLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totalClientesLabel.Location = new Point(15, 54);
            totalClientesLabel.Name = "totalClientesLabel";
            totalClientesLabel.Size = new Size(40, 32);
            totalClientesLabel.TabIndex = 6;
            totalClientesLabel.Text = "15";
            totalClientesLabel.TextChanged += totalClientesLabel_TextChanged;
            totalClientesLabel.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(15, 39);
            label8.Name = "label8";
            label8.Size = new Size(91, 15);
            label8.TabIndex = 5;
            label8.Text = "Total de clientes";
            // 
            // panel5
            // 
            panel5.BackColor = Color.GhostWhite;
            panel5.Controls.Add(label2);
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 29);
            panel5.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(63, 8);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 0;
            label2.Text = "Clientes";
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(panel14);
            panel6.Controls.Add(progressBarProVendidas);
            panel6.Controls.Add(panel13);
            panel6.Controls.Add(progressBarTotalVendas);
            panel6.Controls.Add(proVendaMesLabel);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(totalProVendaLabel);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(panel7);
            panel6.Location = new Point(644, 79);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 310);
            panel6.TabIndex = 6;
            // 
            // panel14
            // 
            panel14.BorderStyle = BorderStyle.Fixed3D;
            panel14.Location = new Point(3, 210);
            panel14.Name = "panel14";
            panel14.Size = new Size(199, 10);
            panel14.TabIndex = 17;
            // 
            // progressBarProVendidas
            // 
            progressBarProVendidas.ForeColor = SystemColors.GrayText;
            progressBarProVendidas.Location = new Point(20, 186);
            progressBarProVendidas.Name = "progressBarProVendidas";
            progressBarProVendidas.Size = new Size(164, 18);
            progressBarProVendidas.Step = 1;
            progressBarProVendidas.Style = ProgressBarStyle.Continuous;
            progressBarProVendidas.TabIndex = 18;
            progressBarProVendidas.Value = 30;
            // 
            // panel13
            // 
            panel13.BorderStyle = BorderStyle.Fixed3D;
            panel13.Location = new Point(0, 113);
            panel13.Name = "panel13";
            panel13.Size = new Size(199, 10);
            panel13.TabIndex = 13;
            // 
            // progressBarTotalVendas
            // 
            progressBarTotalVendas.ForeColor = SystemColors.GrayText;
            progressBarTotalVendas.Location = new Point(20, 89);
            progressBarTotalVendas.Name = "progressBarTotalVendas";
            progressBarTotalVendas.Size = new Size(164, 18);
            progressBarTotalVendas.Step = 1;
            progressBarTotalVendas.Style = ProgressBarStyle.Continuous;
            progressBarTotalVendas.TabIndex = 16;
            progressBarTotalVendas.Value = 30;
            // 
            // proVendaMesLabel
            // 
            proVendaMesLabel.AutoSize = true;
            proVendaMesLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            proVendaMesLabel.Location = new Point(20, 151);
            proVendaMesLabel.Name = "proVendaMesLabel";
            proVendaMesLabel.Size = new Size(40, 32);
            proVendaMesLabel.TabIndex = 7;
            proVendaMesLabel.Text = "15";
            proVendaMesLabel.TextChanged += proVendaMesLabel_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 136);
            label6.Name = "label6";
            label6.Size = new Size(175, 15);
            label6.TabIndex = 6;
            label6.Text = "Propriedades vendidas este mes";
            // 
            // totalProVendaLabel
            // 
            totalProVendaLabel.AutoSize = true;
            totalProVendaLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totalProVendaLabel.Location = new Point(20, 54);
            totalProVendaLabel.Name = "totalProVendaLabel";
            totalProVendaLabel.Size = new Size(40, 32);
            totalProVendaLabel.TabIndex = 5;
            totalProVendaLabel.Text = "15";
            totalProVendaLabel.TextChanged += totalProVendaLabel_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 39);
            label4.Name = "label4";
            label4.Size = new Size(123, 15);
            label4.TabIndex = 1;
            label4.Text = "Propriedades a venda ";
            label4.Click += label4_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.GhostWhite;
            panel7.Controls.Add(label3);
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(200, 29);
            panel7.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(47, 8);
            label3.Name = "label3";
            label3.Size = new Size(102, 21);
            label3.TabIndex = 0;
            label3.Text = "Propriedades";
            // 
            // panel8
            // 
            panel8.BackColor = Color.LightSteelBlue;
            panel8.Location = new Point(2, 1);
            panel8.Name = "panel8";
            panel8.Size = new Size(888, 54);
            panel8.TabIndex = 4;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.Fixed3D;
            panel9.Location = new Point(409, 193);
            panel9.Name = "panel9";
            panel9.Size = new Size(199, 10);
            panel9.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(10, 247);
            button1.Name = "button1";
            button1.Size = new Size(121, 33);
            button1.TabIndex = 29;
            button1.Text = "Definições";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(881, 414);
            Controls.Add(panel8);
            Controls.Add(panel9);
            Controls.Add(panel6);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(MenuPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Activated += UserForm_Activated;
            FormClosed += UserForm_FormClosed;
            Load += UserForm_Load;
            MenuPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MenuPanel;
        private Button buttonGerirUsers;
        private Button buttonGerirPropriedades;
        private Button buttonGerirClientes;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label2;
        private Panel panel6;
        private Panel panel7;
        private Label label3;
        private Panel panel8;
        private Label totalProVendaLabel;
        private Label label4;
        private ProgressBar progressBarTotalCliente;
        private Label clientesFaltaPagLabel;
        private Label label12;
        private Label clientesPropostasLabel;
        private Label label10;
        private Label totalClientesLabel;
        private Label label8;
        private Label proVendaMesLabel;
        private Label label6;
        private ProgressBar progressBarFaltaPag;
        private ProgressBar progressBarClienteProposta;
        private Panel panel10;
        private Panel panel9;
        private Panel panel12;
        private Panel panel11;
        private ProgressBar progressBarTotalFuncionarios;
        private Label LocVendasLabel;
        private Label label15;
        private Label funcionarioMesLLabel;
        private Label label17;
        private Label totalFuncionarios;
        private Label label19;
        private Panel panel14;
        private ProgressBar progressBarProVendidas;
        private Panel panel13;
        private ProgressBar progressBarTotalVendas;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private Button button1;
    }
}