using LR_5.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LR_5.Controllers
{
    public class AdInstController : Controller
    {
        private readonly PostgresContext _pgContext;
        public AdInstController(PostgresContext pgContext)
        {
            _pgContext = pgContext;
        }

        public IActionResult Index()
        {
            var instructors = _pgContext.Instructs.ToList();
            return View(instructors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InstructCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newInstruct = new Instruct
                {
                    SurnameI = model.SurnameI,
                    NameI = model.NameI,
                    Otchestvo = model.Otchestvo,
                    Gender = model.Gender,
                    DateB = DateOnly.Parse(model.DateB),
                    City = model.City,
                    Street = model.Street,
                    House = model.House,
                    Flat = model.Flat,
                    PassNom = model.PassNom,
                    PassSerial = model.PassSerial
                };

                _pgContext.Instructs.Add(newInstruct);
                _pgContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var instructor = _pgContext.Instructs.FirstOrDefault(i => i.InstId == id);

            if (instructor == null)
            {
                return NotFound();
            }

            var editViewModel = new InstructCreateViewModel
            {
                SurnameI = instructor.SurnameI,
                NameI = instructor.NameI,
                Otchestvo = instructor.Otchestvo,
                Gender = instructor.Gender,
                DateB = instructor.DateB.ToString("yyyy-MM-dd"),
                City = instructor.City,
                Street = instructor.Street,
                House = instructor.House,
                Flat = instructor.Flat,
                PassNom = instructor.PassNom,
                PassSerial = instructor.PassSerial
            };

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, InstructCreateViewModel model)
        {
            var instructor = _pgContext.Instructs.FirstOrDefault(i => i.InstId == id);

            if (instructor == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                instructor.SurnameI = model.SurnameI;
                instructor.NameI = model.NameI;
                instructor.Otchestvo = model.Otchestvo;
                instructor.Gender = model.Gender;
                instructor.DateB = DateOnly.Parse(model.DateB);
                instructor.City = model.City;
                instructor.Street = model.Street;
                instructor.House = model.House;
                instructor.Flat = model.Flat;
                instructor.PassNom = model.PassNom;
                instructor.PassSerial = model.PassSerial;

                _pgContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var instructorToDelete = _pgContext.Instructs.Find(id);

            if (instructorToDelete == null)
            {
                return NotFound();
            }

            _pgContext.Instructs.Remove(instructorToDelete);
            _pgContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
