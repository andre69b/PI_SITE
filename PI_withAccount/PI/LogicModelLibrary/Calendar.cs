using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicModelLibrary
{
    public class Calendar
    {
        private GregorianCalendar calendar = new GregorianCalendar();

        private Dictionary<string, int> _dayofweek = new Dictionary<string, int>()
        {
            {"Sunday",0}, {"Monday",1}, {"Tuesday",2}, {"Wednesday",3}, {"Thursday",4}, {"Friday",5}, {"Saturday",6}
        };
        public static Dictionary<string, int> StringMonthToInt = new Dictionary<string, int>()
        {
            {"janeiro",1}, {"fevereiro",2}, {"março",3}, {"abril",4}, {"maio",5}, {"junho",6}, {"julho",7},
            {"agosto",8},{"setembro",9},{"outubro",10},{"novembro",11},{"dezembro",12}
        };

        public class OneDay
        {
            public DateTime Date { get; set; }
            public bool Available { get; set; }

            public OneDay(int year, int month, int day, RealEstate rl)
            {
                Date = new DateTime(year, month, day);
                this.Available = rl._AvailabilityOfTheProperty.ValidateDay(Date);
            }
        }

        public OneDay[][] GetArrayCalendar(RealEstate rl, int year = 2014, int month=1)
        {
            var arr = new OneDay[5][];

            int afteryear = year;
            int aftermonth = month;
            if (month == 12)
            {
                ++afteryear;
                aftermonth = 1;
            }
            else
                ++aftermonth;

            int beforeyear = year;
            int beforemonth = month;
            if (month > 1)
                --beforemonth;
            else
            {
                --beforeyear;
                beforemonth = 12;
            }
            int diasMesAnt = calendar.GetDaysInMonth(beforeyear, beforemonth);
            int diasMes = calendar.GetDaysInMonth(year, month);
            DayOfWeek w = calendar.GetDayOfWeek(new DateTime(year, month, 1));
            int index = _dayofweek[w.ToString()]; // posicao do primeiro dia do mes
            var aux = new OneDay[7]; // 7 = dias da semana
            int count = 0;

            for (int j = 0; j < aux.Length; ++j)
            {
                if (j >= index)
                    aux[j] = new OneDay(year, month, ++count,rl);
                else
                    aux[j] = new OneDay(beforeyear, beforemonth, (diasMesAnt - (index - j)),rl); ;
            }
            arr[0] = aux;
            bool nexmonth = false;
            for (int i = 1; i < arr.Length; ++i)
            {
                aux = new OneDay[7];
                for (int j = 0; j < aux.Length; ++j)
                {
                    if (!nexmonth)
                        aux[j] = new OneDay(year, month, ++count,rl);
                    else
                        aux[j] = new OneDay(afteryear, aftermonth, ++count,rl);

                    if (count == diasMes)
                    {
                        nexmonth = true;
                        count = 0;
                    }
                }
                arr[i] = aux;
            }
            return arr;
        }
    }
}
