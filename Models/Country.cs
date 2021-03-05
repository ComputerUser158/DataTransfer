using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataTransfer.Models
{
    public class Country
    {
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public Game Game { get; set; }
        public Sport Sport { get; set; }
        public string FlagImage { get; set; }
    }
}
