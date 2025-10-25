using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;

namespace HernadVedDispatcher.Services
{
    public static class FirebasePushService
    {
        static bool initialized = false;

        public static void Initialize(string serviceAccountPath)
        {
            if (!initialized)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(serviceAccountPath)
                });
                initialized = true;
            }
        }

        public static async Task SendPushAsync(string token, string title, string body)
        {
            var message = new Message()
            {
                Token = token,
                Notification = new Notification
                {
                    Title = title,
                    Body = body
                }
            };
            await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}