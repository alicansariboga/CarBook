﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int authorCount { get; set; }
        public decimal avgRentPriceForDaily { get; set; }
        public decimal avgRentPriceForWeekly { get; set; }
        public decimal avgRentPriceForMonthly { get; set; }
        public int blogCount { get; set; }
        public string blogTitleByMaxBlogComment { get; set; }
        public int brandCount { get; set; }
        public string brandNameByMaxCar { get; set; }
        public string carBrandAndModelByRentPriceDailyMax { get; set; }
        public string carBrandAndModelByRentPriceDailyMin { get; set; }
        public int carCountByFuelElectric { get; set; }
        public int carCountByFuelGasolineOrDiesel { get; set; }
        public int carCountByKmLT1000 { get; set; }
        public int carCountByTransmissionIsAuto { get; set; }
        public int carCount { get; set; }
        public int locationCount { get; set; } // Random
    }
}
