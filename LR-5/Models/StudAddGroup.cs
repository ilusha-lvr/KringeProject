using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LR_5.Models
{
    public class StudAddGroup
    {
        public int Id { get; set; }
        public List<SelectListItem>? Groups { get; set; }

        public List<SelectListItem>? Students { get; set; }
        
        [Required(ErrorMessage = "Выберите группу.")]
        public int? SelectedGroupId { get; set; }

        [Required(ErrorMessage = "Выберите учащегося.")]
        public int? SelectedStudentId { get; set; }
    }
}