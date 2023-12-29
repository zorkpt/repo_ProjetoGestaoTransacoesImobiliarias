namespace TransacoesImobiliariasWinForms
{
    partial class Erros
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
            textErros = new TextBox();
            SuspendLayout();
            // 
            // textErros
            // 
            textErros.Location = new Point(117, 142);
            textErros.Multiline = true;
            textErros.Name = "textErros";
            textErros.Size = new Size(403, 141);
            textErros.TabIndex = 0;
            // 
            // Erros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(textErros);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Erros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Erros";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textErros;
    }
}