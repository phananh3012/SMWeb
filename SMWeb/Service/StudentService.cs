using Microsoft.AspNetCore.Mvc.Rendering;
using SMWeb.Models;
using SMWeb.Repository.IRepository;
using SMWeb.Service.IService;

namespace SMWeb.Service
{
    public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studentRepository;

		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public IEnumerable<Student> GetAll() => _studentRepository.GetAll();
		public Student Get(int id) => _studentRepository.Get(id);
		public void Add(Student student) => _studentRepository.Add(student);
		public void Update(Student student) => _studentRepository.Update(student);
		public void Remove(int id) => _studentRepository.Remove(id);
		public List<SelectListItem> GenderListItem()
		{
			List<SelectListItem> genderListItem = new()
			{
				new SelectListItem() { Text = "Nam", Value = "1" },
				new SelectListItem() { Text = "Nữ", Value = "2" },
				new SelectListItem() { Text = "Khác", Value = "3" }
			};
			return genderListItem;
		}
	}
}
