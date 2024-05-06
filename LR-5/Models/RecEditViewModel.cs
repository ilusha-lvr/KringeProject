using System;
using System.ComponentModel.DataAnnotations;

namespace LR_5.Models
{
    public class RecEditViewModel
    {
        public int InstId { get; set; }
        public int StudId { get; set; }
        public int CarId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string DateL { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string TimeL { get; set; }
    }
}