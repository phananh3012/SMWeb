
using SMWeb.Models;

namespace SMWeb.Repository
{
	public interface IStudentRepository
	{
		IEnumerable<Student> GetAll();
		Student Get(int id);
		void Add(Student student);
		void Update(Student student);
		void Remove(int id);
	}
}
