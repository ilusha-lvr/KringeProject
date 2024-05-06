using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using LR_5.Models;

namespace LR_5.Controllers
{
    public class TeoryController : Controller
    {
        private readonly PostgresContext _pgContext;

        public TeoryController(PostgresContext pgContext)
        {
            _pgContext = pgContext;
        }

        public async Task<IActionResult> Index()
        {
            var teoryRecords = await _pgContext.Teories
                .Include(t => t.Group)
                .ToListAsync();

            return View(teoryRecords);
        }

        public IActionResult Create()
        {
            ViewBag.Groups = _pgContext.Groups.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(TeoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateL = DateOnly.Parse(model.DateL).ToString("yyyy-MM-dd");
                model.TimeL = TimeOnly.Parse(model.TimeL).ToString("HH:mm");

                var newTeory = new Teory
                {
                    GroupId = model.GroupId,
                    DateL = DateOnly.Parse(model.DateL),
                    TimeL = TimeOnly.Parse(model.TimeL)
                };

                _pgContext.Teories.Add(newTeory);
                _pgContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Groups = _pgContext.Groups.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeoryCreateViewModel model)
        {
            var teoryRecord = await _pgContext.Teories.FindAsync(id);

            if (teoryRecord == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                model.DateL = DateOnly.Parse(model.DateL).ToString("yyyy-MM-dd");
                model.TimeL = TimeOnly.Parse(model.TimeL).ToString("HH:mm");

                teoryRecord.GroupId = model.GroupId;
                teoryRecord.DateL = DateOnly.Parse(model.DateL);
                teoryRecord.TimeL = TimeOnly.Parse(model.TimeL);

                await _pgContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.Groups = _pgContext.Groups.ToList();

            return View("Edit", model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var teoryRecord = await _pgContext.Teories
                .Include(t => t.Group)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (teoryRecord == null)
            {
                return NotFound();
            }

            var editViewModel = new TeoryCreateViewModel
            {
                GroupId = teoryRecord.GroupId,
                DateL = teoryRecord.DateL.ToString("yyyy-MM-dd"),
                TimeL = teoryRecord.TimeL.ToString("HH:mm")
            };

            ViewBag.Groups = _pgContext.Groups.ToList();

            return View(editViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var teoryRecordToDelete = await _pgContext.Teories.FindAsync(id);

            if (teoryRecordToDelete == null)
            {
                return NotFound();
            }

            _pgContext.Teories.Remove(teoryRecordToDelete);
            await _pgContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}