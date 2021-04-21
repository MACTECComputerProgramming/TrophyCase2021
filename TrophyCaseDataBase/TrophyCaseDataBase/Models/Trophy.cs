using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrophyCaseDataBase.Models
{
    public class Trophy
    {
        public int Id { get; set; }
        public int YearEarned { get; set; }
        public string Details { get; set; }
        public string ImagePath { get; set; }


    }
}
