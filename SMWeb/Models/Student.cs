using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMWeb.Models
{
	public class Student
	{
		[Key]
		public int StudentId { get; set; }
		[DisplayName("Họ và tên")]
		[Required(ErrorMessage = "Nhập họ và tên")]
		public string StudentName { get; set; }
		[Range(1, 3, ErrorMessage = "Chọn giới tính")]
		[DisplayName("Giới tính")]
		public int Gender { get; set; }
		[Required(ErrorMessage = "Nhập ngày sinh")]
		[DisplayName("Ngày sinh")]
		public DateTime DOB { get; set; }
		[Required(ErrorMessage = "Nhập tên lớp")]
		[DisplayName("Lớp")]
		public string Class { get; set; }
		[Required(ErrorMessage = "Nhập khóa")]
		[DisplayName("Khóa")]
		public int Course { get; set; }
	}
}
