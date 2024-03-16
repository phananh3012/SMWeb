using SMWeb.Models;
using SMWeb.Repository;

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
	}
}
