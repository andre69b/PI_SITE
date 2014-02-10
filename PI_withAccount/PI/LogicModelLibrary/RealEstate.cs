using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace LogicModelLibrary
{
    public class RealEstate
    {
        public string Username { get; set; }

        public int id { get; set; }
        public string ShortName { get; set; }
        public string LongDescription { get; set; }
        public Album Photos { get; set; }
        public double PricePerWeek { get; set; }
        public Location _Location { get; set; }
        public Feature _Feature { get; set; }
        public Appreciations _Appreciations { get; set; }
        public AvailabilityOfTheProperty _AvailabilityOfTheProperty { get; set; }

        public class Album
        {
            public int Highlight { get; set; }
            public string[] Photos { get; set; }
        }

        public class Location
        {
            public string Local { get; set; }
            public Coordinates Coordinates { get; set; }
        }

        public class Coordinates
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public string getCoordinatesJson()
            {
                return "[\"" + Latitude.ToString().Replace(",", ".") + "\",\"" + Longitude.ToString().Replace(",", ".") + "\"]";  
            }
        }

        public class Feature
        {
            public int Capacity { get; set; }
            public int Dimensions { get; set; }
            public int Sections { get; set; }
            public int Rooms { get; set; }
        }

        public class Appreciations
        {
            public List<Appreciation>_Appreciations { get; set; }
            private double _rank;

            public void AddAppreciation(Appreciation a)
            {
                _Appreciations.Add(a);
                CalculateRank();
            }
            public void CalculateRank()
            {
                _rank = _Appreciations.Average(x => x.Note);
            }
            public double GetRank()
            {
                return _rank;
            }

        }

        public class Appreciation
        {
            public int Note { get; set; }
            public string Author { get; set; }
            public string DescriptionOfAppreciation { get; set; }
            public DateTime DayOfAppreciation { get; set; }
        }

        public class AvailabilityOfTheProperty
        {
            public List<CheckInCheckOut> Restrictions;

            public bool ValidateRestrictions(DateTime dateIn, DateTime dateOut)
            {
                return Restrictions.Find((x) => x.ValidateDate(dateIn, dateOut))==default(CheckInCheckOut);
            }

            public bool AddReservation(DateTime dateIn, DateTime dateOut, string userName)
            {
                if (!ValidateRestrictions(dateIn, dateOut)) return false;

                Restrictions.Add(new CheckInCheckOut(dateIn, dateOut, userName));
                return true;
            }

            public bool ValidateDay(DateTime date)
            {
                return Restrictions.Find((x) => x.ValidateDay(date)) == default(CheckInCheckOut);
            }
        }

        public class CheckInCheckOut
        {
            public DateTime In { get; set; }
            public DateTime Out { get; set; }
            public string UserName { get; set; }

            public CheckInCheckOut(DateTime In, DateTime Out, string userName)
            {
                this.In = In;
                this.Out = Out;
                this.UserName = userName;
            }

            public bool ValidateDate(DateTime dateIn, DateTime dateOut)
            {
                return (dateIn >= In && dateIn <= Out || dateOut >= In && dateOut <= Out || dateIn < In && dateOut > Out);
            }
            public bool ValidateDay(DateTime date)
            {
                return !(In > date || Out < date);
            }
        }
    }
}