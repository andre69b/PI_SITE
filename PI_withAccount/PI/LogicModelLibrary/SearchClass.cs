using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

namespace LogicModelLibrary
{
    public class SearchClass
    {
        private IEnumerable<RealEstate> list;

        public SearchClass(IEnumerable<RealEstate> list)
        {
            this.list = list;
        }

        public IEnumerable<RealEstate> filter()
        {
            this.filterName().filterPriceMax().filterPriceMin().filterAvabylity();
            return list;
        }

        public string Name { get; set; }

        public string Location { get; set; }
        public int? PriceMin { get; set; }
        public int? PriceMax { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? Capacity { get; set; }

        private SearchClass filterPriceMin()
        {
            if (this.PriceMin == null)
                return this;
            list = from estate in this.list
                   where estate.PricePerWeek > this.PriceMin
                   select estate;
            return this;
        }

        private SearchClass filterName()
        {
            if (Name == null)
                return this;
            list = from estate in this.list
                   where estate.ShortName.ToLower().Contains(this.Name.ToLower())
                   select estate;
            return this;
        }

        private SearchClass filterPriceMax()
        {
            if (this.PriceMin == null)
                return this;
            list = from estate in this.list
                   where estate.PricePerWeek < this.PriceMax
                   select estate;
            return this;
        }

        private SearchClass filterAvabylity()
        {
            if (this.CheckIn == null || this.CheckOut == null || this.CheckIn.Value.Date > this.CheckOut.Value.Date)
                return this;

            list = from estate in this.list
                where estate._AvailabilityOfTheProperty.ValidateRestrictions(this.CheckIn.Value, this.CheckOut.Value)
                select estate;
            return this;
        }
    }
}
