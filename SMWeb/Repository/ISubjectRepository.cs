using SMWeb.Models;

namespace SMWeb.Repository
{
	public interface ISubjectRepository
	{
		IEnumerable<Subject> GetAll();
		Subject Get(int id);
		void Add(Subject subject);
		void Update(Subject subject);
		void Remove(int id);
	}
}
