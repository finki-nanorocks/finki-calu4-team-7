using calu4_t7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calu4_t7.ViewModel
{
    public class SchoolClassViewModel
    {
        public SchoolClass SchoolClass { get; set; }
        public int Points { get; set; }
        public int Plastic { get; set; }
        public int Batery { get; set; }
        public int Glass { get; set; }
        public int Papper { get; set; }
        public int FinalPoints { get; set; }


    }
}