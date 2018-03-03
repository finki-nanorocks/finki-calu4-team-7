using calu4_t7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calu4_t7.ViewModel
{
    public class ClassViewModel
    {
        public List<SchoolClassViewModel> List { get; set; }
        public List<ClassChartViewModel> ListChart { get; set; }
        public School School { get; set; }
    }
}