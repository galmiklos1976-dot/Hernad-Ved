using System;

namespace HernadVedDispatcher.Models
{
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public string AlertText { get; set; }
        public string DispatcherName { get; set; }
    }
}