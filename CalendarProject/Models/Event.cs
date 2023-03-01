using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string EventTheme { get; set; }
        public string EventDate { get; set; }
        public string UserId { get; set; }
    }
}