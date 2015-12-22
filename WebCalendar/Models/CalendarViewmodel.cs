﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCalendar.Business;

namespace WebCalendar.Models
{
    public class CalendarViewmodel
    {
        DateTime currentDT = DateTime.Now;

        public int DaysOfCurrentMonth { get; set; }
        public string CurrentMonth { get; set; }
        public int CurrentYear { get; set; }
        public int StartDay { get; set; }
        public int currentMonthDigit { get; set; }
        public DateTime selectedDate { get; set; }

        public CalendarViewmodel()
        {
            StartDay = FirstDayOfMonth(currentDT.Month,currentDT.Year);
            DaysOfCurrentMonth = DateTime.DaysInMonth(currentDT.Year, currentDT.Month);
            CurrentMonth = printMonth(currentDT.Month);
            currentMonthDigit = DateTime.Now.Month;
            CurrentYear = DateTime.Now.Year;
        }

        public CalendarViewmodel(string direction, int month, int year)
        {
            DateHelper date = new DateHelper(direction,month,year);
            StartDay = FirstDayOfMonth(date.getDate.Month,date.getDate.Year);
            DaysOfCurrentMonth = DateTime.DaysInMonth(date.getDate.Year, date.getDate.Month);
            CurrentMonth = printMonth(date.getDate.Month);
            CurrentYear = date.getDate.Year;
            currentMonthDigit = date.getDate.Month;
        }
        private string printMonth(int month)
        {

            switch (month) {

                case 1:
                    return "Januari";
                case 2:
                    return "Februari";
                case 3:
                    return "Mars";
                case 4:
                    return "April";
                case 5:
                    return "Maj";
                case 6:
                    return "Juni";
                case 7:
                    return "Juli";
                case 8:
                    return "Augusti";
                case 9:
                    return "September";
                case 10:
                    return "Oktober";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "";
            }
                
                    
        }

        private int FirstDayOfMonth(int month, int year)
        {
            DateTime date = new DateTime(year, month, 1);   
            return (int)date.DayOfWeek;
        }

     }
}