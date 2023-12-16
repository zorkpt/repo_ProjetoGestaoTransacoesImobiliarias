namespace TransacoesImobiliariasWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoginButton.MouseMove += LoginButton_MouseMove;
            UserNameTex.TextChanged += UserNameText_TextChanged;
            PasswordTxt.TextChanged += PasswordTxt_TextChanged;
        }



        private void LoginButton_Click(object sender, EventArgs e)
        {
           
        }

        private void LoginButton_MouseMove(object sender, EventArgs e)
        {
            if(UserNameTex.Text == "" || PasswordTxt.Text == "")
            {
                LoginButton.Location = new Point(LoginButton.Location.X + 20, LoginButton.Location.Y + 20);
            }
        }

        private void UserNameText_TextChanged(object sender, EventArgs e)
        {
            LoginButton.Location = new Point(135, 106);
        }
        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
            LoginButton.Location = new Point(135, 106);
        }
    }
}
