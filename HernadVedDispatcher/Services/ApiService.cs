using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using HernadVedDispatcher.Models;

namespace HernadVedDispatcher.Services
{
    public static class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<User> LoginAsync(string email, string password)
        {
            var url = $"https://api.hernadved.hu/users?email={email}&password={password}";
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(content);
        }

        public static async Task<List<Customer>> GetCustomersAsync()
        {
            var response = await client.GetAsync("https://api.hernadved.hu/customers");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Customer>>(content);
        }

        public static async Task<bool> AddCustomerAsync(Customer customer)
        {
            var json = JsonSerializer.Serialize(customer);
            var response = await client.PostAsync("https://api.hernadved.hu/customers",
                new StringContent(json, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var json = JsonSerializer.Serialize(customer);
            var response = await client.PutAsync($"https://api.hernadved.hu/customers/{customer.Id}",
                new StringContent(json, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteCustomerAsync(int id)
        {
            var response = await client.DeleteAsync($"https://api.hernadved.hu/customers/{id}");
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<Notification>> GetNotificationsAsync(int customerId)
        {
            var response = await client.GetAsync($"https://api.hernadved.hu/customers/{customerId}/notifications");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Notification>>(content);
        }

        public static async Task<bool> AddNotificationAsync(int customerId, Notification notification)
        {
            var json = JsonSerializer.Serialize(notification);
            var response = await client.PostAsync($"https://api.hernadved.hu/customers/{customerId}/notifications",
                new StringContent(json, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<Alert>> GetAlertsAsync()
        {
            var response = await client.GetAsync("https://api.hernadved.hu/alerts");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Alert>>(content);
        }

        public static async Task<bool> UpdateAlertStatusAsync(int alertId, string status)
        {
            var json = JsonSerializer.Serialize(new { status });
            var response = await client.PutAsync($"https://api.hernadved.hu/alerts/{alertId}",
                new StringContent(json, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }
    }
}