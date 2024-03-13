using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMWeb.Models
{
	public class Subject
	{
		[Key]
		public int SubjectId { get; set; }
		[Required]
		[DisplayName("Tên môn học")]
		public string SubjectName { get; set; }
		[DisplayName("Số tiết học")]
		[Required]
		public int NumberOfPeriod { get; set; }
		[DisplayName("Tỉ lệ điểm QT")]
		[Required]
		[Range(0, 1)]
		public double FirstGradeRate { get; set; }
		[DisplayName("Tỉ lệ điểm TP")]
		[Required]
		[Range(0, 1)]
		public double SecondGradeRate { get; set; }
	}
}
