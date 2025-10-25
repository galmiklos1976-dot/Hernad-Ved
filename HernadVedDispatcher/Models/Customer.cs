using System.Collections.Generic;

namespace HernadVedDispatcher.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}