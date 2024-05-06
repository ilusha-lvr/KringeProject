using LR_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LR_5.Controllers
{
    public class GroupController : Controller
    {
        private readonly PostgresContext _pgContext;

        public GroupController(PostgresContext pgContext)
        {
            _pgContext = pgContext;
        }

        public IActionResult Index()
        {
            var groups = _pgContext.Groups.ToList();
            return View(groups);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Group group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newGroup = new Group
                    {
                        TypeGroup = group.TypeGroup
                    };
                    _pgContext.Groups.Add(newGroup);
                    _pgContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(group);
            }
            catch (Exception ex)
            {
                // Печать информации об ошибке в консоль (или в лог)
                Console.WriteLine(ex.Message);

                // Вернуть ошибку пользователю (или перенаправить на другую страницу с ошибкой)
                ModelState.AddModelError("", "Произошла ошибка при сохранении данных в базе.");
                return View(group);
            }
        }

        public IActionResult Edit(int id)
        {
            var group = _pgContext.Groups
                .FirstOrDefault(g => g.GroupId == id);

            if (group == null)
            {
                return NotFound();
            }

            var editViewModel = new Group
            {
                GroupId = group.GroupId,
                TypeGroup = group.TypeGroup
            };

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, Group model)
        {
            var group = _pgContext.Groups
                .FirstOrDefault(g => g.GroupId == id);

            if (group == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
  
                group.TypeGroup = model.TypeGroup;

                _pgContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var group = _pgContext.Groups.Find(id);

            if (group == null)
            {
                return NotFound();
            }

            _pgContext.Groups.Remove(group);
            _pgContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}