using BlogSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.Model
{
    public class SiteContact : Entity<int>
    {
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Phone2 { get; set; }
        public string Adress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
