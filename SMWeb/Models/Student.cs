using System.ComponentModel.DataAnnotations;

namespace SMWeb.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        [Range(0, 2)]
        public int Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public int Course { get; set; }
    }
}
