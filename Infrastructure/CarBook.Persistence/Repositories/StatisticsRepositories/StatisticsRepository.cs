using CarBook.Persistence.Context;
using CarBoook.Application.Interfaces.StatisticsInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            // Select Avg(Amount) from CarPricings where PricingID=(Select PricingID from Pricings Wheree Name='Günlük')
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return values;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return values;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return values;
        }

        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var values = _context.Comments.GroupBy(x => x.BlogID).
                                Select(y => new
                                {
                                    BlogID = y.Key,
                                    Count = y.Count()
                                }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogName;

            //if (string.IsNullOrEmpty(blogName)){
            //    //NullReferenceException;
            //};
        }

        public int GetBrandCount()
        {
            var values = _context.Brands.Count();
            return values;
        }

        public string GetBrandNameByMaxCar()
        {
            // Select BrandID,Count(*) From Cars Group By BrandID Order By Count(*) desc

            var values = _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //Select * From CarPricings where Amount=(Select Max(Amount) From CarPricings where PricingID=3)
            // SELECT Model, CarPricings.CarID, Amount FROM dbo.CarPricings WHERE Inner Join Cars ON CarPricings.CarID=Cars.CarID WHERE PricingID=(SELECT PricingID FROM Pricings WHERE Name='Günlük') and Amount=(SELECT Max(Amount) FROM CarPricings WHERE PricingID=(SELECT PricingID FROM Where Name='Günlük'))
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var values = _context.Cars.Count();
            return values;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmLT1000()
        {
            var values = _context.Cars.Where(x => x.Km <= 1000).Count();
            return values;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var values = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return values;
        }

        public int GetLocationCount()
        {
            var values = _context.Locations.Count();
            return values;
        }
    }
}
