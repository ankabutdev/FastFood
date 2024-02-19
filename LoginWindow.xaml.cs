using Dapper;
using FastFood.Constants;
using FastFood.Entites.Users;
using FastFood.Enums;
using Npgsql;
using System.Threading.Tasks;
using System.Windows;

namespace FastFood;

/// <summary>
/// Interaction logic for LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    private NpgsqlConnection _connection;


    public LoginWindow()
    {
        InitializeComponent();
        this._connection = new NpgsqlConnection(DbConstant.DB_CONNECTION_STRING);
    }

    private async void btnSubmit_Click(object sender, RoutedEventArgs e)
    {
        var user = new User();
        string username = txtUsername.Text;
        string password = txtPassword.Password.ToString();

        var result = await RegisterAsync(username, password);
        if (result == "admin")
        {

            MainWindow main = new MainWindow(IdentityRole.Admin, 7);

            main.Show();
            this.Close();
        }
        else if (result == "user")
        {
            MainWindow main = new MainWindow(IdentityRole.User, 6);

            main.Show();
            this.Close();
        }
        else MessageBox.Show("User NotFound");
    }

    public async Task<string> RegisterAsync(string username, string password)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT identity_role FROM users WHERE username=@UserName AND password_hash=@PasswordHash;";
            var parameters = new { UserName = username, PasswordHash = password };
            var count = await _connection.ExecuteScalarAsync<string>(query, parameters);
            return count;
        }
        catch
        {
            return "";
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}