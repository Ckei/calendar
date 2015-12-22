using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalendar.Business
{
    public class DateHelper
    {
        DateTime date;
        int newMonth = DateTime.Now.Month;
        int newYear = DateTime.Now.Year;

        public DateTime getDate { get; set; }
        public DateHelper(string direction, int month, int year)
        {
            getDate = NextMonthAndYear(direction,month,year);
        }

        private DateTime NextMonthAndYear(string direction, int month, int year)
        {

            if (direction == ">")
            {
                int Month;

                if (month != 12)
                {
                        Month = month + 1;
                        date = new DateTime(year, Month, 1);

                    return date;
                }
                else
                {
                    newYear = year + 1;
                    Month = month - 11;
                    date = new DateTime(newYear, Month, 1);

                    return date;
                }


            }

            else if (direction == "<")
            {
                if (month != 1)
                {

                        int Month = month - 1;
                        date = new DateTime(year, Month, 1);

                    return date;
                }
                else
                {
                    newYear = year - 1;
                    newMonth = month + 11;
                    date = new DateTime(newYear, newMonth, 1);

                    return date;
                }
            }
            else
            {
                date = new DateTime(1, 1, 1);
                return date;
            }
        }
    }
}


