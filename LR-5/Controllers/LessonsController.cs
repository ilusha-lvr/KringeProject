using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using LR_5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

public class LessonsController : Controller
{
    private readonly PostgresContext _pgContext;

    public LessonsController(PostgresContext pgContext)
    {
        _pgContext = pgContext;
    }

    [Authorize(Roles = "instruct")]
    public IActionResult Index(string role, int usId)
    {
        if (role == "instruct")
        {
            ViewBag.Role = role;
            ViewBag.UsId = usId;
            var lessonRecords = _pgContext.Recs
                .Include(r => r.Inst)
                .Include(r => r.Stud)
                .Include(r => r.Car)
                .Where(r => r.Inst.InstId == usId)
                .ToList();

            return View(lessonRecords);
        }

        return RedirectToAction("AccessDenied", "Account");
    }
    [Authorize(Roles = "user")]
    public IActionResult IndexM(string role, int usId)
    {
        if (role == "user")
        {
            ViewBag.Role = role;
            ViewBag.UsId = usId;

            var lessonRecords = _pgContext.Recs
                .Include(r => r.Inst)
                .Include(r => r.Stud)
                .Include(r => r.Car)
                .Where(r => r.Stud.StudId == usId)
                .ToList();

            var theoryClasses = _pgContext.ListGs
                .Where(g => g.IdStud == usId)
                .SelectMany(g => _pgContext.Teories
                    .Where(t => t.GroupId == g.IdGroup)
                    .Select(t => new
                    {
                        GroupName = g.IdGroupNavigation.GroupId,
                        DateL = t.DateL,
                        TimeL = t.TimeL
                    }))
                .ToList();

            ViewBag.LessonRecords = lessonRecords;
            ViewBag.TheoryClasses = theoryClasses;

            return View();
        }

        return RedirectToAction("AccessDenied", "Account");
    }

}