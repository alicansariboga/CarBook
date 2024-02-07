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
            throw new NotImplementedException();
        }

        public int GetBrandCount()
        {
            var values = _context.Brands.Count();
            return values;
        }

        public string GetBrandNameByMaxCar()
        {
            // Select BrandID,Count(*) From Cars Group By BrandID Order By Count(*) desc
            // Select Brands.Name FROM dbo.Cars INNER JOIN dbo.Brands ON dbo.Cars.BrandID = dbo.Brands.BrandID
            // var values = _context.Cars.FromSql($"Select BrandID,Count(*) From dbo.Cars Group By BrandID Order By Count(*) desc").Max(x => x.Brand);
            //return values;
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            // SELECT Model, CarPricings.CarID, Amount FROM dbo.CarPricings WHERE Inner Join Cars ON CarPricings.CarID=Cars.CarID WHERE PricingID=(SELECT PricingID FROM Pricings WHERE Name='Günlük') and Amount=(SELECT Max(Amount) FROM CarPricings WHERE PricingID=(SELECT PricingID FROM Where Name='Günlük'))
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
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
