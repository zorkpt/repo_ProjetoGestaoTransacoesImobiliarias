namespace TransacoesImobiliariasWinForms
{
    partial class FormPropriedades
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
            ListaPropriedades = new Button();
            panel1 = new Panel();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button1 = new Button();
            ApagarPropriedade = new Button();
            AtualizarPropriedade = new Button();
            AddPropriedade = new Button();
            panel8 = new Panel();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            MenuPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPanel
            // 
            MenuPanel.BackColor = Color.GhostWhite;
            MenuPanel.Controls.Add(LimparCampos);
            MenuPanel.Controls.Add(ListaPropriedades);
            MenuPanel.Controls.Add(panel1);
            MenuPanel.Controls.Add(button1);
            MenuPanel.Controls.Add(ApagarPropriedade);
            MenuPanel.Controls.Add(AtualizarPropriedade);
            MenuPanel.Controls.Add(AddPropriedade);
            MenuPanel.Location = new Point(0, 54);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(166, 433);
            MenuPanel.TabIndex = 16;
            // 
            // LimparCampos
            // 
            LimparCampos.Location = new Point(12, 222);
            LimparCampos.Name = "LimparCampos";
            LimparCampos.Size = new Size(121, 23);
            LimparCampos.TabIndex = 14;
            LimparCampos.Text = "Limpar Campos";
            LimparCampos.UseVisualStyleBackColor = true;
            // 
            // ListaPropriedades
            // 
            ListaPropriedades.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ListaPropriedades.Location = new Point(12, 149);
            ListaPropriedades.Name = "ListaPropriedades";
            ListaPropriedades.Size = new Size(123, 52);
            ListaPropriedades.TabIndex = 13;
            ListaPropriedades.Text = "Ver lista de propriedades";
            ListaPropriedades.UseVisualStyleBackColor = true;
            ListaPropriedades.Click += ListaPropriedades_Click;
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
            // ApagarPropriedade
            // 
            ApagarPropriedade.Font = new Font("Segoe UI", 12F);
            ApagarPropriedade.Location = new Point(12, 94);
            ApagarPropriedade.Name = "ApagarPropriedade";
            ApagarPropriedade.Size = new Size(121, 33);
            ApagarPropriedade.TabIndex = 12;
            ApagarPropriedade.Text = "Apagar Propriedade";
            ApagarPropriedade.UseVisualStyleBackColor = true;
            // 
            // AtualizarPropriedade
            // 
            AtualizarPropriedade.Font = new Font("Segoe UI", 12F);
            AtualizarPropriedade.Location = new Point(12, 55);
            AtualizarPropriedade.Name = "AtualizarPropriedade";
            AtualizarPropriedade.Size = new Size(121, 33);
            AtualizarPropriedade.TabIndex = 11;
            AtualizarPropriedade.Text = "Atualizar Cliente";
            AtualizarPropriedade.UseVisualStyleBackColor = true;
            // 
            // AddPropriedade
            // 
            AddPropriedade.Font = new Font("Segoe UI", 12F);
            AddPropriedade.Location = new Point(12, 16);
            AddPropriedade.Name = "AddPropriedade";
            AddPropriedade.Size = new Size(121, 33);
            AddPropriedade.TabIndex = 10;
            AddPropriedade.Text = "Adicionar cliente";
            AddPropriedade.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            panel8.BackColor = Color.LightSteelBlue;
            panel8.Location = new Point(0, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(912, 54);
            panel8.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(234, 88);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 19;
            label1.Text = "Tipo imóvel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(234, 136);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 20;
            label2.Text = "Area";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(370, 172);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(234, 178);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 22;
            label3.Text = "Proprietario";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(370, 128);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(121, 23);
            textBox2.TabIndex = 23;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(370, 80);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 24;
            // 
            // FormPropriedades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(881, 414);
            Controls.Add(comboBox2);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MenuPanel);
            Controls.Add(panel8);
            MaximizeBox = false;
            Name = "FormPropriedades";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPropriedades";
            MenuPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel MenuPanel;
        private Button LimparCampos;
        private Button ListaPropriedades;
        private Panel panel1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button1;
        private Button ApagarPropriedade;
        private Button AtualizarPropriedade;
        private Button AddPropriedade;
        private Panel panel8;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox textBox2;
        private ComboBox comboBox2;
    }
}