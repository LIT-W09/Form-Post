using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11.Models
{
    public class SearchProdutsViewModel
    {
        public List<Product> Products { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}