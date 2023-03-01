using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
    }
}
