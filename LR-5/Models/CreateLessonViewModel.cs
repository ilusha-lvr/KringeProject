using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace LR_5.Models
{
    public class CreateLessonViewModel
    {
        [Required(ErrorMessage = "Выберите ученика")]
        public int SelectedStudentId { get; set; }

        [Required(ErrorMessage = "Выберите машину")]
        public int SelectedCarId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string DateL { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string TimeL { get; set; }

        public SelectList Student { get; set; }

        public SelectList Cars { get; set; }
    }
}
