using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calu4_t7.Models
{
    public class RecycleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public const byte Plastic = 1;
        public const byte Glass = 2;
        public const byte Battery = 3;
    }
}