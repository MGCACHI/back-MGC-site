using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geo_starter.Models
{
    public class car
    {
        string text = "jer ar shemosula";
        string t;
        int year;
        int y;

        public string Model { get; set; }
        public int Year
        {
            get
            {
                if(year>1980)
                {
                    y = year;
                }
                return y;
            }
            set
            {
                year = value;
            }
        }

    }
}