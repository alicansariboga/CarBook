﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BannerDtos
{
    public class UpdateBannerDto
    {
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public string VideoDescripton { get; set; }
        public string VideoUrl { get; set; }
    }
}
