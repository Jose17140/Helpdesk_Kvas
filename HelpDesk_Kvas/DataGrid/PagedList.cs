using HelpDesk_Kvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk_Kvas.DataGrid
{
    public class PagedList<T>
    {
        public List<T> Content { get; set; }
        public List<T> Content2 { get; set; }
        public List<T> Content3 { get; set; }

        public Int32 CurrentPage { get; set; }
        public Int32 PageSize { get; set; }
        public int TotalRecords { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalRecords / PageSize); }
        }
        public int Nv1 { get; set; }
        public int Nv2 { get; set; }
        public int Nv3 { get; set; }
    }
}