using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calu4_t7.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; } 
    }
}