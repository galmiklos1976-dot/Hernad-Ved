using System.Windows;
using HernadVedDispatcher.Services;
using HernadVedDispatcher.Models;

namespace HernadVedDispatcher.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailBox.Text;
            var password = PasswordBox.Password;

            var user = await ApiService.LoginAsync(email, password);
            if (user == null)
            {
                ErrorText.Text = "Hibás belépési adatok!";
                return;
            }

            if (email == "gal.miklos1976@gmail.com")
            {
                var adminWindow = new AdminView(user);
                adminWindow.Show();
            }
            else
            {
                var dispatcherWindow = new DispatcherView(user);
                dispatcherWindow.Show();
            }
            this.Close();
        }
    }
}