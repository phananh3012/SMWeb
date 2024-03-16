using SMWeb.Models;

namespace SMWeb.Service
{
	public interface ISubjectService
	{
		IEnumerable<Subject> GetAll();
		Subject Get(int id);
		void Add(Subject subject);
		void Update(Subject subject);
		void Remove(int id);
	}
}
