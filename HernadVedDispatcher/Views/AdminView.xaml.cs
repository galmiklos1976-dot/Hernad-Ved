using System.Windows;
using System.Collections.Generic;
using HernadVedDispatcher.Models;
using HernadVedDispatcher.Services;

namespace HernadVedDispatcher.Views
{
    public partial class AdminView : Window
    {
        private User _user;

        public AdminView(User user)
        {
            InitializeComponent();
            _user = user;
            WelcomeText.Text = $"Üdv, {_user?.Name ?? _user?.Email}";
            _ = LoadCustomersAsync();
        }

        private async void RefreshCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadCustomersAsync();
        }

        private async System.Threading.Tasks.Task LoadCustomersAsync()
        {
            try
            {
                StatusText.Text = "Betöltés...";
                var customers = await ApiService.GetCustomersAsync();
                CustomersGrid.ItemsSource = customers;
                StatusText.Text = $"Betöltve: {customers?.Count ?? 0} ügyfél";
            }
            catch (System.Exception ex)
            {
                StatusText.Text = "Hiba a betöltéskor";
                Helpers.ToastHelper.ShowError(ex.Message);
            }
        }
    }
}