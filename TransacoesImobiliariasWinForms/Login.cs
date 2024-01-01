using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;

namespace TransacoesImobiliariasWinForms
{
    public partial class LoginForm : Form
    {
        public FormsController _formController;
        public PaymentController _paymentController;

        public LoginForm()
        {
            InitializeComponent();
            LoginButton.MouseMove += LoginButton_MouseMove;
            UserNameTex.TextChanged += UserNameText_TextChanged;
            PasswordTxt.TextChanged += PasswordTxt_TextChanged;

            _formController = new FormsController();

            string pc = Environment.MachineName;
            if (pc == "DESKTOP-1I7MJQ")//apenas para não estar sempre a fazer login
            {
                User user = _formController.StartLoginProcess("' or 1=1 --", "w", "sql");
                _formController.Start(user, this);
            }
      
            this.Hide();
        }



        private void LoginButton_Click(object sender, EventArgs e)
        {


            User user = _formController.StartLoginProcess(UserNameTex.Text, PasswordTxt.Text, "sql");
            if (user == null)
            {
                MessageBox.Show("User ou Password não foram encontrados");
                return;
            }
            _formController.Start(user, this);


        }

        private void LoginButton_MouseMove(object sender, EventArgs e)
        {
            if (UserNameTex.Text == "" || PasswordTxt.Text == "")
            {
                LoginButton.Location = new Point(LoginButton.Location.X + 20, LoginButton.Location.Y + 20);
                return;
            }

            LoginButton.TabStop = true;

        }

        private void UserNameText_TextChanged(object sender, EventArgs e)
        {
            LoginButton.Location = new Point(135, 106);
        }
        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
            LoginButton.Location = new Point(135, 106);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PasswordTxt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void PasswordTxt_KeyDown(object sender, KeyEventArgs e)
        {

            if (UserNameTex.Text != "" || PasswordTxt.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LoginButton.TabStop = true;
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    e.Handled = true;
                }
            }
        
        }

        private void UserNameTex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }
    }
}
