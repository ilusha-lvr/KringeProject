using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LR_5.Models
{
    public class StudCreateViewModel
    {
        public int StudId { get; set; }

        public int CatId { get; set; }

        public int InstId { get; set; }

        public string Surname { get; set; } = null!;

        public string NameS { get; set; } = null!;

        public string Otchestvo { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string DateS { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string? DateE { get; set; }

        public bool Exam { get; set; }

    }
}
