using Microsoft.AspNetCore.Mvc.Rendering;
using SMWeb.Models;
using SMWeb.Repository.IRepository;
using SMWeb.Service.IService;

namespace SMWeb.Service
{
    public class ClassroomService : IClassroomService
	{
		private readonly IClassroomRepository _classroomRepository;
		private readonly ISubjectRepository _subjectRepository;
		private readonly IStudentRepository _studentRepository;

		public ClassroomService(IClassroomRepository classroomRepository, ISubjectRepository subjectRepository, IStudentRepository studentRepository)
		{
			_classroomRepository = classroomRepository;
			_subjectRepository = subjectRepository;
			_studentRepository = studentRepository;

		}

		public Classroom GetClassroom(int id) => _classroomRepository.Get(id);

		public IEnumerable<Classroom> GetBySubject(int id) => _classroomRepository.GetBySubject(id);

		public IEnumerable<Subject> GetSubjects() => _subjectRepository.GetAll();

		public string GetSubjectName(int id) => _subjectRepository.Get(id).SubjectName;

		public string GetStudentName(int id) => _studentRepository.Get(id).StudentName;

		public void Update(Classroom classroom) => _classroomRepository.Update(classroom);

		public void UpdateFinalGrade(Classroom classroom)
		{
			Subject subject = _subjectRepository.Get(classroom.SubjectId);
			classroom.FinalGrade = classroom.FirstGrade * subject.FirstGradeRate + classroom.SecondGrade * subject.SecondGradeRate;
			_classroomRepository.Update(classroom);
		}

		public void Add(Classroom classroom) => _classroomRepository.Add(classroom);

		public void Remove(int id) => _classroomRepository.Remove(id);

		public List<SelectListItem> StudentListItem()
		{
			List<SelectListItem> studentListItem = new(_studentRepository.GetAll().Select(u => new SelectListItem
			{
				Text = u.StudentName,
				Value = u.StudentId.ToString()
			}));
			return studentListItem;
		}
	}
}
