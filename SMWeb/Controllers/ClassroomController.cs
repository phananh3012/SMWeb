using Microsoft.AspNetCore.Mvc;
using SMWeb.Models;
using SMWeb.Repository;
using SMWeb.ViewModels;

namespace SMWeb.Controllers
{
	public class ClassroomController : Controller
	{
		private readonly IClassroomRepository _classroomRepo;
		private readonly ISubjectRepository _subjectRepo;
		private readonly IStudentRepository _studentRepo;

		public ClassroomController(IClassroomRepository classroomRepo, ISubjectRepository subjectRepo, IStudentRepository studentRepo)
		{
			_classroomRepo = classroomRepo;
			_subjectRepo = subjectRepo;
			_studentRepo = studentRepo;
		}
		public IActionResult Index()
		{
			List<ClassroomVM> classVM = new();
			var classList = _classroomRepo.GetAll();
			foreach (var classMember in classList)
			{
				classVM.Add(new ClassroomVM
				{
					StudentName = _studentRepo.Get(classMember.StudentId).StudentName,
					SubjectName = _subjectRepo.Get(classMember.SubjectId).SubjectName,
					Classroom = classMember
				});
			}
			return View(classVM);
		}
		public IActionResult Edit(int id)
		{
			Classroom classroom = _classroomRepo.Get(id);
			ClassroomVM classroomVM = new()
			{
				Classroom = classroom,
				StudentName = _studentRepo.Get(classroom.StudentId).StudentName,
				SubjectName = _subjectRepo.Get(classroom.SubjectId).SubjectName,
			};
			return View(classroomVM);
		}
		[HttpPost]
		public IActionResult Edit(ClassroomVM classroomVM)
		{
			_classroomRepo.Update(classroomVM.Classroom);
			Subject subject = _subjectRepo.Get(classroomVM.Classroom.SubjectId);
			_classroomRepo.UpdateFinalGrade(subject.FirstGradeRate, subject.SecondGradeRate, classroomVM.Classroom.ClassroomId);
			return RedirectToAction("Index");
		}
	}
}
