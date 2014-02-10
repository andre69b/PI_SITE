using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicModelLibrary
{
    
    public class Info
    {
        public static readonly int ElemPerPage = 4;
        public static readonly int SEARCH = 1;
        public static readonly int DEFAULT  = 0;


        public IEnumerable<RealEstate> LiEstates { get; set; }
        public readonly int Total;

        public readonly int Page;

        public string Text { get; set; }
        public int PageType = 0;

        public Info(IEnumerable<RealEstate> arr, int page, int type = 0)
        {
            List<RealEstate> aux = new List<RealEstate>(3);
            RealEstate[] l = arr.ToArray();
            for (int i = Info.ElemPerPage*page; i < l.Length && i < Info.ElemPerPage*page + Info.ElemPerPage; i++)
            {
                aux.Add(l[i]);
            }
            this.LiEstates = aux;
            this.Total = l.Length/Info.ElemPerPage;

            if (l.Length % Info.ElemPerPage != 0)
            {
                 this.Total++;
            }
            PageType = type; 
            this.Page = page;
            this.Text = "{" + type + "}";

        }


    }
}
