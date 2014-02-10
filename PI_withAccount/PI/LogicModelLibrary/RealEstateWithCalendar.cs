using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LogicModelLibrary
{
    public class RealEstateWithCalendar
    {
        public class ChangeMonth
        {
            public string Year { get; set; }
            public string Month { get; set;}
            public string Move { get; set; }
            public string Type { get; set; }

            public int GetYear(){   return int.Parse(Year);}
            public int GetMonth() { return Calendar.StringMonthToInt[Month];}
        }

        public class CalendarCheck
        {
            public Calendar.OneDay[][] Array;
            public string Type;

            public CalendarCheck(Calendar.OneDay[][] Array, string Type)
            {
                this.Array = Array;
                this.Type = Type;
            }

            public string GetJson()
            {
                var ret = new StringBuilder("[");
                foreach (var arry in Array)
                {
                    foreach (var e in arry)
                    {
                        if (e.Available)
                            ret.Append(e.Date.Ticks + ",");
                    }
                }
                ret.Remove(ret.Length - 1, 1);
                ret.Append("]");
                return ret.ToString();

            }

        }
        public class Check
        {
            public string CheckIn { get; set; }
            public string CheckOut { get; set; }

            public DateTime GetDateTimeCheckIn()
            {
                return GetDateTime(CheckIn);
            }
            public DateTime GetDateTimeCheckOut()
            {
                return GetDateTime(CheckOut);
            }
            public DateTime GetDateTime(string date)
            {
                string aux = date.Substring(0, date.Length - 1);
                long value = long.Parse(aux);
                return new DateTime(value);
            }
        }
       

        public RealEstate realEstate;
        public CalendarCheck arrayCalendarCheckIn;
        public CalendarCheck arrayCalendarCheckOut;

        public RealEstateWithCalendar(RealEstate realEstate, Calendar.OneDay[][] arrayCalendarCheckIn, Calendar.OneDay[][] arrayCalendarCheckOut)
        {
            this.realEstate = realEstate;
            this.arrayCalendarCheckIn = new CalendarCheck(arrayCalendarCheckIn,"I");
            this.arrayCalendarCheckOut = new CalendarCheck(arrayCalendarCheckOut,"O");
        }
    }
}
