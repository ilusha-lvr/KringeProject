using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LR_5.Models
{
    public class AddStudentViewModel
    {
        public int SelectedGroupId { get; set; }

        public int SelectedStudentId { get; set; }

        public List<SelectListItem> Groups { get; set; }

        public List<SelectListItem> Students { get; set; }

        public string GroupType { get; set; }

        public List<Stud> StudentsNotInGroup { get; set; }
    }
}