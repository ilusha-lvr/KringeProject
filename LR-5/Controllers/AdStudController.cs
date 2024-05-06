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
    public class AdStudController : Controller
    {
        private readonly PostgresContext _pgContext;

        public AdStudController(PostgresContext pgContext)
        {
            _pgContext = pgContext;
        }

        public IActionResult Index()
        {
            var students = _pgContext.Studs
                .Include(s => s.Inst)
                .Include(s => s.Cat)
                .ToList();

            return View(students);
        }
        public IActionResult IndexM()
        {
            var students = _pgContext.Studs
                .Include(s => s.Inst)
                .Include(s => s.Cat)
                .ToList();

            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Categories = _pgContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(StudCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    // Вывести ошибку в лог или отправить ее в представление
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            if (ModelState.IsValid)
            {
                model.DateS = DateOnly.Parse(model.DateS).ToString("yyyy-MM-dd");
                var newStud = new Stud
                {
                    CatId = model.CatId,
                    InstId = model.InstId,
                    Surname = model.Surname,
                    NameS = model.NameS,
                    Otchestvo = model.Otchestvo,
                    DateS = DateOnly.Parse(model.DateS)
                };
                _pgContext.Studs.Add(newStud);
                _pgContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Categories = _pgContext.Categories.ToList();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var student = _pgContext.Studs
                .Include(s => s.Inst)
                .Include(s => s.Cat)
                .FirstOrDefault(s => s.StudId == id);

            if (student == null)
            {
                return NotFound();
            }
            var editViewModel = new StudCreateViewModel
            {
                CatId = student.CatId,
                InstId = student.InstId,
                Surname = student.Surname,
                NameS = student.NameS,
                Otchestvo = student.Otchestvo,
                DateS = student.DateS.ToString("yyyy-MM-dd"),
                //DateE = student.DateE.ToString("yyyy-MM-dd"),
                Exam = student.Exam
            };

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Categories = _pgContext.Categories.ToList();

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, StudCreateViewModel model)
        {
            //var student = _pgContext.Studs.Find(id);
            var student = _pgContext.Studs
                .Include(s => s.Inst)
                .Include(s => s.Cat)
                .FirstOrDefault(s => s.StudId == id);

            if (student == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                model.DateS = DateOnly.Parse(model.DateS).ToString("yyyy-MM-dd");
                if (model.DateE != null)
                {
                    model.DateE = DateOnly.Parse(model.DateE).ToString("yyyy-MM-dd");
                }

                student.CatId = model.CatId;
                student.InstId = model.InstId;
                student.Surname = model.Surname;
                student.NameS = model.NameS;
                student.Otchestvo = model.Otchestvo;
                student.DateS = DateOnly.Parse(model.DateS);
               
                if (model.DateE != null)
                {
                    student.DateE = DateOnly.Parse(model.DateE);
                }
                student.Exam = model.Exam;

                _pgContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Categories = _pgContext.Categories.ToList();

            return View(model);
        }
        public IActionResult EditM(int id)
        {
            var student = _pgContext.Studs
                .Include(s => s.Inst)
                .Include(s => s.Cat)
                .FirstOrDefault(s => s.StudId == id);

            if (student == null)
            {
                return NotFound();
            }
            var editViewModel = new StudCreateViewModel
            {
                CatId = student.CatId,
                InstId = student.InstId,
                Surname = student.Surname,
                NameS = student.NameS,
                Otchestvo = student.Otchestvo,
                DateS = student.DateS.ToString("yyyy-MM-dd"),
                //DateE = student.DateE.ToString("yyyy-MM-dd"),
                Exam = student.Exam
            };

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Categories = _pgContext.Categories.ToList();

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult EditM(int id, StudCreateViewModel model)
        {
            //var student = _pgContext.Studs.Find(id);
            var student = _pgContext.Studs
                .Include(s => s.Inst)
                .Include(s => s.Cat)
                .FirstOrDefault(s => s.StudId == id);

            if (student == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                model.DateS = DateOnly.Parse(model.DateS).ToString("yyyy-MM-dd");
                if (model.DateE != null)
                {
                    model.DateE = DateOnly.Parse(model.DateE).ToString("yyyy-MM-dd");
                }

                student.CatId = model.CatId;
                student.InstId = model.InstId;
                student.Surname = model.Surname;
                student.NameS = model.NameS;
                student.Otchestvo = model.Otchestvo;
                student.DateS = DateOnly.Parse(model.DateS);

                if (model.DateE != null)
                {
                    student.DateE = DateOnly.Parse(model.DateE);
                }
                student.Exam = model.Exam;

                _pgContext.SaveChanges();
                return RedirectToAction("IndexM");
            }

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Categories = _pgContext.Categories.ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var studentToDelete = _pgContext.Studs.Find(id);

            if (studentToDelete == null)
            {
                return NotFound();
            }

            _pgContext.Studs.Remove(studentToDelete);
            _pgContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
