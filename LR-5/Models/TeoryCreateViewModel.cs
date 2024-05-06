using System;
using System.ComponentModel.DataAnnotations;

namespace LR_5.Models
{
    public class TeoryCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Group is required")]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public string DateL { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [DataType(DataType.Time)]
        public string TimeL { get; set; }
    }
}