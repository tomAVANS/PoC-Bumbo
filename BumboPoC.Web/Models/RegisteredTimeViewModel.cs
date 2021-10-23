using BumboPoC.Domain;

namespace BumboPoC.Web.Models
{
    public class RegisteredTimeViewModel
    {
        public Employee Employee { get; set; }
        public TimeBlock TimeBlock { get; set; }
        public TimeEntry TimeEntry { get; set; }
        public double TimeDifference { get; set; }
    }
}