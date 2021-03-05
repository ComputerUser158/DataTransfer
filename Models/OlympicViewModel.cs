using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataTransfer.Models
{
    public class OlympicViewModel
    {
        public Country Country { get; set; }
        public string ActiveGame { get; set; } = "all";
        public string ActiveSport { get; set; } = "all";
    }
}