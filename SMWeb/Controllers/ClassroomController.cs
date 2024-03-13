using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
			var subjectList = _subjectRepo.GetAll();
			if (subjectList == null)
			{
				return NotFound();
			}
			return View(subjectList);
		}
		public IActionResult Detail(int id)
		{
			List<ClassroomVM> classVM = new();
			var classList = _classroomRepo.GetBySubject(id);
			string subjectName = _subjectRepo.Get(id).SubjectName;
			if (classList == null || subjectName == null)
			{
				return NotFound();
			}
			foreach (var classMember in classList)
			{
				classVM.Add(new ClassroomVM
				{
					StudentName = _studentRepo.Get(classMember.StudentId).StudentName,
					Classroom = classMember
				});
			}
			ViewBag.SubjectName = subjectName;
			ViewBag.SubjectId = id;
			return View(classVM);
		}
		public IActionResult Create(int id)
		{
			Classroom classroom = new() { SubjectId = id };
			List<SelectListItem> StudentList = new(_studentRepo.GetAll().Select(u => new SelectListItem
			{
				Text = u.StudentName,
				Value = u.StudentId.ToString()
			}));

			ViewBag.StudentList = StudentList;
			return View(classroom);
		}
		[HttpPost]
		public IActionResult Create(Classroom classroom)
		{
			if (ModelState.IsValid)
			{
				_classroomRepo.Add(classroom);
				return RedirectToAction("Detail", new { id = classroom.SubjectId });
			}
			List<SelectListItem> StudentList = new(_studentRepo.GetAll().Select(u => new SelectListItem
			{
				Text = u.StudentName,
				Value = u.StudentId.ToString()
			}));

			ViewBag.StudentList = StudentList;
			return View();
		}
		public IActionResult Edit(int id)
		{

			Classroom classroom = _classroomRepo.Get(id);
			ClassroomVM classroomVM = new()
			{
				Classroom = classroom,
				StudentName = _studentRepo.Get(classroom.StudentId).StudentName,
			};
			return View(classroomVM);
		}
		[HttpPost]
		public IActionResult Edit(ClassroomVM classroomVM)
		{
			if (ModelState.IsValid)
			{
				_classroomRepo.Update(classroomVM.Classroom);
				Subject subject = _subjectRepo.Get(classroomVM.Classroom.SubjectId);
				_classroomRepo.UpdateFinalGrade(subject.FirstGradeRate, subject.SecondGradeRate, classroomVM.Classroom.ClassroomId);
				return RedirectToAction("Detail", new { id = subject.SubjectId });
			}
			return View(classroomVM);
		}
		public IActionResult Delete(int id, int subId)
		{
			_classroomRepo.Remove(id);
			return RedirectToAction("Detail", new { id = subId });
		}
	}
}
