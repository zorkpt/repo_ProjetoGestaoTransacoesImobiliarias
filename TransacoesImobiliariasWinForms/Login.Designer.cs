﻿namespace TransacoesImobiliariasWinForms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            UserNameTex = new TextBox();
            LoginButton = new Button();
            PasswordTxt = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 30);
            label1.Name = "label1";
            label1.Size = new Size(89, 21);
            label1.TabIndex = 0;
            label1.Text = "User Name";
            // 
            // UserNameTex
            // 
            UserNameTex.Location = new Point(135, 28);
            UserNameTex.Name = "UserNameTex";
            UserNameTex.Size = new Size(159, 23);
            UserNameTex.TabIndex = 1;
            UserNameTex.KeyDown += UserNameTex_KeyDown;
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginButton.Location = new Point(135, 106);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(159, 28);
            LoginButton.TabIndex = 3;
            LoginButton.TabStop = false;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(135, 67);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PasswordChar = '*';
            PasswordTxt.Size = new Size(159, 23);
            PasswordTxt.TabIndex = 2;
            PasswordTxt.TextChanged += PasswordTxt_TextChanged_1;
            PasswordTxt.KeyDown += PasswordTxt_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(40, 69);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(342, 184);
            Controls.Add(PasswordTxt);
            Controls.Add(label2);
            Controls.Add(LoginButton);
            Controls.Add(UserNameTex);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox UserNameTex;
        private Button LoginButton;
        private TextBox PasswordTxt;
        private Label label2;
    }
}
