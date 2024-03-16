using System.ComponentModel;
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
		[Range(0, 10)]
		[DisplayName("Điểm quá trình")]
		public double FirstGrade { get; set; }
		[Range(0, 10)]
		[DisplayName("Điểm thành phần")]
		public double SecondGrade { get; set; }
		[Range(0, 10)]
		public double FinalGrade { get; set; }
		public enum Result

		{
			Pass = 1,
			Fail = 0
		}
	}
}
