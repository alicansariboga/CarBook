using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetAuthorCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMonthly();
        int GetBlogCount();
        string GetBlogTitleByMaxBlogComment(); 
        int GetBrandCount();
        string GetBrandNameByMaxCar();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();
        int GetCarCountByFuelElectric();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByKmLT1000();
        int GetCarCountByTransmissionIsAuto();
        int GetCarCount();
        int GetLocationCount();


    }
}
