using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalendar.Business
{
    public class UserMessages
    {
        private string date { get; set; }
        private string message { get; set; }

        public UserMessages(string date, string message)
        {
            this.date = date;
            this.message = message;
        }

        public string Date {
            get { return date; }
            set { date = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }

        }
    }
}