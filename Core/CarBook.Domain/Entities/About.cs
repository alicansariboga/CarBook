﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class About
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public string ImageUrl { get; set; }
    }
}
