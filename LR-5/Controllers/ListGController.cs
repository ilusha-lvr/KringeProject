using LR_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Diagnostics;
public class ListGController : Controller
{
    private readonly PostgresContext _pgContext;
 
    public ListGController(PostgresContext pgContext)
    {
        _pgContext = pgContext;
    }
   
    [HttpGet]
    public IActionResult Index()
    {
        var viewModel = new ListGViewModel
        {
            GroupOptions = _pgContext.Groups.Select(g => g.GroupId).ToList(),
            DisplayStudents = false
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Index(ListGViewModel model)
    {
        if (model.SelectedGroupId != 0)
        {
            model.Students = _pgContext.ListGs
                .Where(lg => lg.IdGroup == model.SelectedGroupId)
                .Select(lg => new Stud
                {
                    StudId = lg.IdStud,  // Используем StudId из таблицы ListG
                    Surname = lg.IdStudNavigation.Surname,
                    NameS = lg.IdStudNavigation.NameS,
                    Otchestvo = lg.IdStudNavigation.Otchestvo
                })
                .ToList();

            model.SelectedGroupType = _pgContext.Groups
                .Where(g => g.GroupId == model.SelectedGroupId)
                .Select(g => g.TypeGroup)
                .FirstOrDefault();

            model.DisplayStudents = true;
        }
        else
        {
            model.DisplayStudents = false;
        }

        model.GroupOptions = _pgContext.Groups.Select(g => g.GroupId).ToList();

        return View(model);
    }
    [HttpGet]
    public IActionResult AddStudentForm()
    {
        var viewModel = new StudAddGroup
        {
            Groups = GetGroupSelectList(),
            Students = GetStudentsNotInAnyGroup()
        };

        return View("Create", viewModel);
    }


    // ... другие методы

    private List<SelectListItem> GetGroupSelectList()
    {
        var groupOptions = _pgContext.Groups
            .Select(g => new SelectListItem
            {
                Value = g.GroupId.ToString(),
                Text = $"{g.TypeGroup} (ID: {g.GroupId})"
            })
            .ToList();

        return groupOptions;
    }

    private List<SelectListItem> GetStudentsNotInAnyGroup()
    {
        var studentsNotInGroup = _pgContext.Studs
            .Where(s => !_pgContext.ListGs.Any(lg => lg.IdStud == s.StudId))
            .Select(s => new SelectListItem
            {
                Value = s.StudId.ToString(),
                Text = $"{s.Surname} {s.NameS} {s.Otchestvo}"
            })
            .ToList();

        return studentsNotInGroup;
    }
    [HttpPost]
    public IActionResult AddStudentToGroup(StudAddGroup model)
    {
        if (ModelState.IsValid)
        {
            // Создаем новую запись в ListG
            var newListG = new ListG
            {
                IdGroup = model.SelectedGroupId.Value,
                IdStud = model.SelectedStudentId.Value,
            };

            // Добавляем запись в базу данных
            _pgContext.ListGs.Add(newListG);
            _pgContext.SaveChanges();

            // Перенаправляем пользователя на Index
            return RedirectToAction("Index");
        }

        // Если модель недопустима, возвращаем на представление AddStudentForm
        model.Groups = GetGroupSelectList();
        model.Students = GetStudentsNotInAnyGroup();
        return View("Create", model);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        // Находим запись в таблице ListG по id
        var listGItem = _pgContext.ListGs.Find(id);

        if (listGItem != null)
        {
            // Удаляем запись из контекста
            _pgContext.ListGs.Remove(listGItem);

            // Сохраняем изменения в базе данных
            _pgContext.SaveChanges();
        }

        // Перенаправляем пользователя на нужную страницу, например, Index
        return RedirectToAction("Index");
    }
}