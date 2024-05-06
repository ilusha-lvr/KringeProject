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
    public class AvController : Controller
    {
        private readonly PostgresContext _pgContext;

        public AvController(PostgresContext pgContext)
        {
            _pgContext = pgContext;
        }
        public IActionResult Index()
        {
            var records = _pgContext.Recs
                .Include(r => r.Inst)
                .Include(r => r.Stud)
                .Include(r => r.Car)
                .ToList();

            return View(records);
        }
        public IActionResult Create()
        {
            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Students = _pgContext.Studs.ToList();
            ViewBag.Cars = _pgContext.Cars.ToList(); 

            return View();
        }

        [HttpPost]
        public IActionResult Create(RecCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateL = DateOnly.Parse(model.DateL).ToString("yyyy-MM-dd");
                model.TimeL = TimeOnly.Parse(model.TimeL).ToString("HH:mm");

                var newRec = new Rec
                {
                    InstId = model.InstId,
                    StudId = model.StudId,
                    CarId = model.CarId,
                    DateL = DateOnly.Parse(model.DateL),
                    TimeL = TimeOnly.Parse(model.TimeL)
                };

                _pgContext.Recs.Add(newRec);
                _pgContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Students = _pgContext.Studs.ToList();
            ViewBag.Cars = _pgContext.Cars.ToList();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var record = _pgContext.Recs
                .Include(r => r.Inst)
                .Include(r => r.Stud)
                .Include(r => r.Car)
                .FirstOrDefault(r => r.RecId == id);

            if (record == null)
            {
                return NotFound();
            }

            var editViewModel = new RecCreateViewModel
            {
                InstId = record.InstId,
                StudId = record.StudId,
                CarId = record.CarId,
                DateL = record.DateL.ToString("yyyy-MM-dd"),
                TimeL = record.TimeL.ToString("HH:mm")
            };

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Students = _pgContext.Studs.ToList();
            ViewBag.Cars = _pgContext.Cars.ToList();

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, RecCreateViewModel model)
        {
            var record = _pgContext.Recs
                .Include(r => r.Inst)
                .Include(r => r.Stud)
                .Include(r => r.Car)
                .FirstOrDefault(r => r.RecId == id);

            if (record == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                model.DateL = DateOnly.Parse(model.DateL).ToString("yyyy-MM-dd");
                model.TimeL = TimeOnly.Parse(model.TimeL).ToString("HH:mm");

                record.InstId = model.InstId;
                record.StudId = model.StudId;
                record.CarId = model.CarId;
                record.DateL = DateOnly.Parse(model.DateL);
                record.TimeL = TimeOnly.Parse(model.TimeL);

                _pgContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Students = _pgContext.Studs.ToList();
            ViewBag.Cars = _pgContext.Cars.ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _pgContext.Recs.Find(id);

            if (recordToDelete == null)
            {
                return NotFound();
            }

            _pgContext.Recs.Remove(recordToDelete);
            _pgContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
