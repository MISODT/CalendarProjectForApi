using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CalendarProject.Models;
using System.Collections.ObjectModel;
using System.Collections;
using CalendarProject.Views;
using System.Net;

namespace CalendarProject.Database
{
    public class Request
    {
        private string GetResponseFromRequest(string request)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(request);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string jsonString = "";

            using(StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                jsonString = reader.ReadToEnd();
            }

            return jsonString;
        }

        public List<User> GetUsers()
        {
            string json = GetResponseFromRequest($"http://f0784727.xsph.ru/users");

            var users = JsonSerializer.Deserialize<UsersMessage>(json);

            return users.Users;
        }

        public List<Event> GetEvents()
        {
            string json = GetResponseFromRequest($"http://f0784727.xsph.ru/events");

            var events = JsonSerializer.Deserialize<EventsMessage>(json);

            return events.Events;
        }

        public void UpdateEvent(string eventTheme, string eventDate, string eventUserId)
        {
            GetResponseFromRequest($"http://f0784727.xsph.ru/?eventTheme={eventTheme}&eventDate={eventDate}&eventUserId={eventUserId}&isEventUpdating=true");
        }

        public void DeleteEvent(string eventId)
        {
            GetResponseFromRequest($"http://f0784727.xsph.ru/?eventId={eventId}");
        }

        public void InsertUser(string userName, string userLogin, string userPassword)
        {
            GetResponseFromRequest($"http://f0784727.xsph.ru/?userName={userName}&userLogin={userLogin}&userPassword={userPassword}");
        }

        public void InsertEvent(string eventTheme, string eventDate, string eventUserId)
        {
            GetResponseFromRequest($"http://f0784727.xsph.ru/?eventTheme={eventTheme}&eventDate={eventDate}&eventUserId={eventUserId}");
        }
    }
}
