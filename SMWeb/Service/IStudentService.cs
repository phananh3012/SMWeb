using SMWeb.Models;

namespace SMWeb.Service
{
	public interface IStudentService
	{
		IEnumerable<Student> GetAll();
		Student Get(int id);
		void Add(Student student);
		void Update(Student student);
		void Remove(int id);
	}
}
