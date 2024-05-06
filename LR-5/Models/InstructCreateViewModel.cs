using System.ComponentModel.DataAnnotations;
using LR_5.Models;

namespace LR_5.Models
{
    public class InstructCreateViewModel
    {
        public int InstId { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string SurnameI { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string NameI { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Otchestvo { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string DateB { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string City { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string House { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int Flat { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string PassNom { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string PassSerial { get; set; }
    }
}