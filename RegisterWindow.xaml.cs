using System.Windows;
using System.Windows.Input;

namespace FastFood
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown_SignIn(object sender, MouseButtonEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Border_MouseDown_Register(object sender, MouseButtonEventArgs e)
        {
            //int cnt = 0;
            //if (Tb_FirstName.Text.Length > 0 && Tb_FirstName.Text.Length < 32) cnt += 1;
            //if (Tb_SecondName.Text.Length > 0 && Tb_SecondName.Text.Length < 32) cnt += 1;
            //if (Tb_Email.Text.Length > 0 && Tb_Email.Text.Length < 32 && Tb_Email.Text.Contains('@') && Tb_Email.Text.Contains('.')) cnt += 1;
            //if (Tb_Password.Password.Length >= 8 && Tb_Password.Password.Length < 32) cnt += 1;

            //if (cnt == 4)
            //{
            //    var admin = new Admins();
            //    admin.first_name = Tb_FirstName.Text;
            //    admin.last_name = Tb_SecondName.Text;
            //    admin.email = Tb_Email.Text;

            //    string password = Tb_Password.Password.ToString();
            //    var hasherResult = Hashing.Hash(password);

            //    admin.password_hash = hasherResult.PasswordHash;
            //    admin.salt = hasherResult.salt;

            //    try
            //    {
            //        var dbResult = await Register(admin);
            //        if (dbResult) { MessageBox.Show("Successfully Registred!! "); this.Close(); }
            //        else MessageBox.Show("!! Error Try again !!");
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Error Something wrong");

            //    }

            //}
            //else MessageBox.Show("Check your informations , something wrong !😑 ");
        }
    }
}
