using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBoook.Application.Interfaces.CarInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }

        // son 5 arabayi listeleme
        public List<Car> GetLast5CarsWithBrands()
        {
            // select top(5) * from cars order by carID desc
            var values = _context.Cars.Include(_x => _x.Brand).OrderByDescending(x=>x.CarID).Take(5).ToList();
            return values;
        }
    }
}
