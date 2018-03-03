using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calu4_t7.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Municiplaity { get; set; }

        //public ICollection<SchoolClass> Classes { get; set; }
    }
}