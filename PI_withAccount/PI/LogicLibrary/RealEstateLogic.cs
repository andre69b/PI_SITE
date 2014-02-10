using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LogicModelLibrary;

namespace LogicLibrary
{
    public class RealEstateLogic : IRealEstateLogic
    {
        private static volatile int size;
        private static List<RealEstate> _RealEstate = new List<RealEstate>();

        public RealEstateLogic()
        {
            
               var r1 = new RealEstate()
               {
                    Username = "Diogo",
                    ShortName="Casinha Bora Lá",
                    LongDescription="Casa pequena mas acolhedora",
                    Photos= new RealEstate.Album(){Highlight=0, Photos = new []{"272.jpg","18579676.jpg"}},
                    PricePerWeek = 200.0,
                    _Location= new RealEstate.Location(){Local="Atras do  Monte", Coordinates = new RealEstate.Coordinates(){ Latitude=32.650241, Longitude = -16.857143}},
                    _Feature = new RealEstate.Feature(){Capacity=2,Dimensions=10,Sections=2,Rooms=1},
                    _Appreciations= new RealEstate.Appreciations(){_Appreciations=new List<RealEstate.Appreciation>(){new RealEstate.Appreciation(){ Note=5,DescriptionOfAppreciation="Very good Home!!!",DayOfAppreciation= new DateTime(2012,12,24),Author="Zé Cabra"}}},
                    _AvailabilityOfTheProperty = new RealEstate.AvailabilityOfTheProperty()
                    {
                        Restrictions = new List<RealEstate.CheckInCheckOut>()
                        {
                            new RealEstate.CheckInCheckOut(new DateTime(2014,1,1),new DateTime(2014,1,2),"ADMIN")
                        }
                    }
               };
               r1._Appreciations.CalculateRank();
               AddRealEstate(r1);
               r1 = new RealEstate()
               {
                   Username = "Diogo",
                   ShortName = "Castelo louco",
                   LongDescription = "Casa mais que acolhedora",
                   Photos = new RealEstate.Album() { Highlight = 0, Photos = new[] { "11584962.jpg", "17794427.jpg" } },
                   PricePerWeek = 300.0,
                   _Location = new RealEstate.Location() { Local = "À Frente do  Monte", Coordinates = new RealEstate.Coordinates() { Latitude = 38.752071, Longitude = -9.183052 } },
                   _Feature = new RealEstate.Feature() { Capacity = 5, Dimensions = 200, Sections = 5, Rooms = 15 },
                   _Appreciations = new RealEstate.Appreciations() { _Appreciations = new List<RealEstate.Appreciation>() { new RealEstate.Appreciation() { Note = 5, DescriptionOfAppreciation = "Very good!!!", DayOfAppreciation = new DateTime(2012, 11, 24), Author = "Tio Alberto" } } },
                   _AvailabilityOfTheProperty = new RealEstate.AvailabilityOfTheProperty()
                   {
                       Restrictions = new List<RealEstate.CheckInCheckOut>()
                        {
                            new RealEstate.CheckInCheckOut(new DateTime(2014,1,1),new DateTime(2014,1,2),"ADMIN")
                        }
                   }
               };
               r1._Appreciations.CalculateRank();
               AddRealEstate(r1);
               r1 = new RealEstate()
               {
                   Username = "Diogo",
                   ShortName = "Casa",
                   LongDescription = "Casa horrivel",
                   Photos = new RealEstate.Album() { Highlight = 0, Photos = new[] { "13510581.jpg", "4098699.jpg" } },
                   PricePerWeek = 25.0,
                   _Location = new RealEstate.Location() { Local = "Num buraco", Coordinates = new RealEstate.Coordinates() { Latitude = 32.646756, Longitude = -16.90948 } },
                   _Feature = new RealEstate.Feature() { Capacity = 2, Dimensions = 20, Sections = 2, Rooms = 1 },
                   _Appreciations = new RealEstate.Appreciations() { _Appreciations = new List<RealEstate.Appreciation>() { new RealEstate.Appreciation() { Note = 1, DescriptionOfAppreciation = "Nada bom!!", DayOfAppreciation = new DateTime(2010, 11, 24), Author = "Tio olé" } } },
                   _AvailabilityOfTheProperty = new RealEstate.AvailabilityOfTheProperty()
                   {
                       Restrictions = new List<RealEstate.CheckInCheckOut>()
                        {
                            new RealEstate.CheckInCheckOut(new DateTime(2014,1,1),new DateTime(2014,1,2),"ADMIN")
                        }
                   }
               };
               r1._Appreciations.CalculateRank();                
               AddRealEstate(r1);
               r1 = new RealEstate()
               {
                   Username = "ADMIN",
                   ShortName = "Casota",
                   LongDescription = "Não recomenda a mais que uma pessoa",
                   Photos = new RealEstate.Album() { Highlight = 0, Photos = new[] { "18805413.jpg", "13437320.jpg" } },
                   PricePerWeek = 150.0,
                   _Location = new RealEstate.Location() { Local = "Debaixo da ponte", Coordinates = new RealEstate.Coordinates() { Latitude = 37.136971, Longitude = -8.539461 } },
                   _Feature = new RealEstate.Feature() { Capacity = 1, Dimensions = 25, Sections = 1, Rooms = 1 },
                   _Appreciations = new RealEstate.Appreciations() { _Appreciations = new List<RealEstate.Appreciation>() { new RealEstate.Appreciation() { Note = 2, DescriptionOfAppreciation = "Very good!!!", DayOfAppreciation = new DateTime(2012, 1, 24), Author = "Rui" } } },
                   _AvailabilityOfTheProperty = new RealEstate.AvailabilityOfTheProperty()
                   {
                       Restrictions = new List<RealEstate.CheckInCheckOut>()
                        {
                            new RealEstate.CheckInCheckOut(new DateTime(2014,1,1),new DateTime(2014,1,2),"Diogo")
                        }
                   }
               };
               r1._Appreciations.CalculateRank();
               AddRealEstate(r1);
               r1 = new RealEstate()
               {
                   Username = "ADMIN",
                   ShortName = "Casa Perfeita",
                   LongDescription = "Casa espetacular",
                   Photos = new RealEstate.Album() { Highlight = 0, Photos = new[] { "11829213.jpg", "13684023.jpg" } },
                   PricePerWeek = 500.0,
                   _Location = new RealEstate.Location() { Local = "Vista para o Mar", Coordinates = new RealEstate.Coordinates() { Latitude = 41.148626, Longitude = -8.625356 } },
                   _Feature = new RealEstate.Feature() { Capacity = 7, Dimensions = 400, Sections = 5, Rooms = 4 },
                   _Appreciations = new RealEstate.Appreciations() { _Appreciations = new List<RealEstate.Appreciation>() { new RealEstate.Appreciation() { Note = 5, DescriptionOfAppreciation = "Very good!!!", DayOfAppreciation = new DateTime(2013, 1, 10), Author = "Zita" } } },
                   _AvailabilityOfTheProperty = new RealEstate.AvailabilityOfTheProperty()
                   {
                       Restrictions = new List<RealEstate.CheckInCheckOut>()
                        {
                            new RealEstate.CheckInCheckOut(new DateTime(2014,1,1),new DateTime(2014,1,2),"Diogo")
                        }
                   }
               };
               r1._Appreciations.CalculateRank();
               AddRealEstate(r1);
            
        }


        public IEnumerable<RealEstate> GetAll()
        {
            return _RealEstate;
        }

        public string GetAllJson()
        {
            var ret = new StringBuilder("[");
            foreach (var realEstate in _RealEstate)
            {
                ret.Append("\""+realEstate.ShortName+"\"");
                ret.Append(',');
                ret.Append(realEstate._Location.Coordinates.Latitude.ToString().Replace(',','.'));
                ret.Append(',');
                ret.Append(realEstate._Location.Coordinates.Longitude.ToString().Replace(',', '.'));
                ret.Append(',');
            }
            ret.Remove(ret.Length - 1, 1);
            ret.Append("]");
            return ret.ToString();
        }

        public RealEstate GeTById(int id)
        {
            return _RealEstate.Find((a)=>a.id==id);
        }
        public IEnumerable<RealEstate> GeTByUserName(string username)
        {
            return _RealEstate.FindAll((a) => a.Username == username); 
        }

        public IEnumerable<RealEstate> GetRealEstateRegisterByUserNameGeTByUserName(string username)
        {
            return _RealEstate.FindAll((a) => a._AvailabilityOfTheProperty.Restrictions.Find(x => x.UserName == username) != default(RealEstate.CheckInCheckOut));
        }

        public RealEstate AddRealEstate(RealEstate realEstate)
        {
            int aux = Interlocked.Increment(ref size);
            realEstate.id = --aux;
            _RealEstate.Add(realEstate);
            return realEstate;
        }
    }
}
