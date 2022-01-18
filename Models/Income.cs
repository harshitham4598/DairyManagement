using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilkDairy.Models
{
    public class Income
    {
        public string dairy_name { get; set; }
        public decimal slno { get; set; }
        public DateTime date { get; set; }
        public string contact_person { get; set; }
        public decimal amount { get; set; }


    }
}