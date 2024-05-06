using System.ComponentModel.DataAnnotations;

namespace LR_5.Models
{
    public class ListG
    {
        [Key]
        public int Id { get; set; }

        public int IdStud { get; set; }
        public int IdGroup { get; set; }
        public virtual Group IdGroupNavigation { get; set; }
        public virtual Stud IdStudNavigation { get; set; }
    }
}