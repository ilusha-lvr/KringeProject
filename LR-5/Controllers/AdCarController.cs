using LR_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace LR_5.Controllers
{
    public class AdCarController : Controller
    {
        private readonly PostgresContext _pgContext;

        public AdCarController(PostgresContext pgContext)
        {
            _pgContext = pgContext;
        }
        public IActionResult Index()
        {
            var cars = _pgContext.Cars.ToList();
            return View(cars);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                if (car.ImageFile != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        car.ImageFile.CopyTo(memoryStream);
                        car.Img = memoryStream.ToArray();
                    }
                }

                _pgContext.Cars.Add(car);
                _pgContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        public IActionResult Edit(int id)
        {
            var car = _pgContext.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                var existingCar = _pgContext.Cars.AsNoTracking().FirstOrDefault(c => c.CarId == car.CarId);

                if (car.ImageFile == null && existingCar != null)
                {
                    car.Img = existingCar.Img;
                }
                else if (car.ImageFile != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        car.ImageFile.CopyTo(memoryStream);
                        car.Img = memoryStream.ToArray();
                    }
                }

                _pgContext.Entry(car).State = EntityState.Modified;
                _pgContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var carToDelete = _pgContext.Cars.Find(id);

            if (carToDelete == null)
            {
                return NotFound();
            }

            _pgContext.Cars.Remove(carToDelete);
            _pgContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ViewImage(int carId)
        {
            var car = GetCarById(carId);

            if (car != null && car.Img != null)
            {
                return View("ViewImage", car);
            }

            return NotFound();
        }

        private Car GetCarById(int carId)
        {
            return _pgContext.Cars
                .Where(c => c.CarId == carId)
                .FirstOrDefault();
        }
    }
}

