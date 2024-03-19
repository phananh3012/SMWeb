using SMWeb.Models;
using SMWeb.Repository;

namespace SMWeb.Service
{
	public class SubjectService : ISubjectService
	{
		private readonly ISubjectRepository _subjectRepository;

		public SubjectService(ISubjectRepository subjectRepository)
		{
			_subjectRepository = subjectRepository;
		}

		public IEnumerable<Subject> GetAll() => _subjectRepository.GetAll();
		public Subject Get(int id) => _subjectRepository.Get(id);
		public void Add(Subject subject) => _subjectRepository.Add(subject);
		public void Update(Subject subject) => _subjectRepository.Update(subject);
		public void Remove(int id) => _subjectRepository.Remove(id);
	}
}
