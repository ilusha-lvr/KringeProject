using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LR_5.Models
{
    public class ListGViewModel
    {
        
        public int Id { get; set; }
        public List<int> GroupOptions { get; set; } 
        public int SelectedGroupId { get; set; }
        public string SelectedGroupType { get; set; } 
        public List<Stud> Students { get; set; } 
        public bool DisplayStudents { get; set; } 
    }
}