using LR_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LR_5.Controllers
{
    public class AdUserController : Controller
    {
        private readonly PostgresContext _pgContext;

        public AdUserController(PostgresContext pgContext)
        {
            _pgContext = pgContext;
        }

        public IActionResult Index()
        {
            var users = _pgContext.Users.ToList();
            return View(users);
        }
        public IActionResult Create()
        {
            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Students = _pgContext.Studs.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                Console.WriteLine($"Role: {model.Role}");
                Console.WriteLine($"InstructorId: {model.InstructorId}");
                Console.WriteLine($"InstructorSurname: {model.InstructorSurname}");
                Console.WriteLine($"InstructorName: {model.InstructorName}");
                Console.WriteLine($"StudentId: {model.StudentId}");
                Console.WriteLine($"UserSurname: {model.UserSurname}");
                Console.WriteLine($"UserName: {model.UsName}");
                var user = new User
                {
                    Username = model.Username,
                    PasswordHash = (model.Password),
                    Role = model.Role,
                    CreatedAt = DateTime.Now,
                };

                if (model.Role == "user")
                {
                    user.Surname = model.UserSurname;
                    user.NameP = model.UsName;
                    user.IdUs = model.StudentId;
                }
                else if (model.Role == "instruct")
                {
                    user.Surname = model.InstructorSurname;
                    user.NameP = model.InstructorName;
                    user.IdUs = model.InstructorId;
                }
                else if (model.Role == "admin")
                {
                    user.Surname = model.AdminSurname;
                    user.NameP = model.AdminName;
                }
                else if (model.Role == "metod")
                {
                    user.Surname = model.MetSurname;
                    user.NameP = model.MetName;
                }

                _pgContext.Users.Add(user);
                _pgContext.SaveChanges();

                return RedirectToAction("Index");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
            }

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Students = _pgContext.Studs.ToList();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var user = _pgContext.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Instructors = _pgContext.Instructs.ToList();
            ViewBag.Students = _pgContext.Studs.ToList();

            var model = new CreateUserViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.PasswordHash,
                Role = user.Role,  
                AdminSurname = user.Surname,
                AdminName = user.NameP,
                MetSurname = user.Surname,
                MetName = user.NameP,
                InstructorId = user.IdUs,
                InstructorSurname = user.Surname,
                InstructorName = user.NameP,
                StudentId = user.IdUs,
                UserSurname = user.Surname,
                UsName = user.NameP
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CreateUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _pgContext.Users.Find(model.UserId);

                    if (user == null)
                    {
                        return NotFound();
                    }

                    user.Username = model.Username;
                    user.PasswordHash = model.Password;

                    _pgContext.Entry(user).State = EntityState.Modified;
                    _pgContext.SaveChanges();

                    return RedirectToAction("Index");
                }

                ViewBag.Instructors = _pgContext.Instructs.ToList();
                ViewBag.Students = _pgContext.Studs.ToList();
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during edit: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userToDelete = _pgContext.Users.Find(id);

            if (userToDelete == null)
            {
                return NotFound();
            }

            _pgContext.Users.Remove(userToDelete);
            _pgContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}