using System;

namespace HernadVedDispatcher.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
    }
}