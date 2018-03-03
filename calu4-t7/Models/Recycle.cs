using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calu4_t7.Models
{
    public class Recycle
    {
        public int Id { get; set; }
        public int Units { get; set; }
        public DateTime DateStamp { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public int SchoolClassId { get; set; }
        public RecycleType RecycleType { get; set; }
        public int RecycleTypeId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
    }
}