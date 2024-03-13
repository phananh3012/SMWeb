using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMWeb.Models
{
	public class Student
	{
		[Key]
		public int StudentId { get; set; }
		[DisplayName("Họ và tên")]
		[Required]
		public string? StudentName { get; set; }
		[Required]
		[Range(0, 2)]
		[DisplayName("Giới tính")]
		public int Gender { get; set; }
		[Required]
		[DisplayName("Ngày sinh")]
		public DateTime DOB { get; set; }
		[Required]
		[DisplayName("Lớp")]
		public string? Class { get; set; }
		[Required]
		[DisplayName("Khóa")]
		public int Course { get; set; }
	}
}
