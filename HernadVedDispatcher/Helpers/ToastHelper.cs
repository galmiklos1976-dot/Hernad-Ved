using System.Windows;

namespace HernadVedDispatcher.Helpers
{
    public static class ToastHelper
    {
        public static void ShowToast(string message)
        {
            MessageBox.Show(message, "Hernád-Véd", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}