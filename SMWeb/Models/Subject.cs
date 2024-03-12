using System.ComponentModel.DataAnnotations;

namespace SMWeb.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public int NumberOfPeriod { get; set; }
        [Required]
        [Range(0, 1)]
        public double FirstGradeRate { get; set; }
        [Required]
        [Range(0, 1)]
        public double SecondGradeRate { get; set; }
    }
}
