using SMWeb.Models;

namespace SMWeb.Repository
{
	public interface IClassroomRepository
	{
		Classroom Get(int id);
		IEnumerable<Classroom> GetBySubject(int id);
		void Update(Classroom classroom);
		void Add(Classroom classroom);
		void Remove(int id);
	}
}
