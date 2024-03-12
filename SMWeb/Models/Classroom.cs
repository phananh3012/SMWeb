﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMWeb.Models
{
    public class Classroom
    {
        [Key]
        public int ClassroomId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        [Range(0, 10)]
        [DisplayName("Điểm quá trình")]
        public double FirstGrade { get; set; }
        [Required]
        [Range(0, 10)]
        [DisplayName("Điểm thành phần")]
        public double SecondGrade { get; set; }
        [Required]
        [Range(0, 10)]
        public double FinalGrade { get; set; }
        [Required]
        public string Result { get; set; }
    }
}