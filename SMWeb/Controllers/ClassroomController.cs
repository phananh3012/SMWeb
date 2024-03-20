using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMWeb.Models;
using SMWeb.Service.IService;
using SMWeb.ViewModels;

namespace SMWeb.Controllers
{
    public class ClassroomController : Controller
	{
		private readonly IClassroomService _classroomService;

		public ClassroomController(IClassroomService classroomService)
		{
			_classroomService = classroomService;
		}

		public IActionResult Index()
		{
			var subjectList = _classroomService.GetSubjects();
			if (subjectList == null)
			{
				return NotFound();
			}
			return View(subjectList);
		}

		public IActionResult Detail(int id)
		{
			var classList = _classroomService.GetBySubject(id);
			string subjectName = _classroomService.GetSubjectName(id);
			if (classList == null || subjectName == null)
			{
				return NotFound();
			}
			List<ClassroomVM> classVM = new();
			foreach (var classMember in classList)
			{
				classVM.Add(new ClassroomVM
				{
					StudentName = _classroomService.GetStudentName(classMember.StudentId),
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
			List<SelectListItem> StudentList = _classroomService.StudentListItem();
			ViewBag.StudentList = StudentList;
			return View(classroom);
		}

		[HttpPost]
		public IActionResult Create(Classroom classroom)
		{
			if (ModelState.IsValid)
			{
				_classroomService.Add(classroom);
				return RedirectToAction("Detail", new { id = classroom.SubjectId });
			}
			List<SelectListItem> StudentList = _classroomService.StudentListItem();
			ViewBag.StudentList = StudentList;
			return View();
		}

		public IActionResult Edit(int id)
		{
			Classroom classroom = _classroomService.GetClassroom(id);
			ClassroomVM classroomVM = new()
			{
				Classroom = classroom,
				StudentName = _classroomService.GetStudentName(classroom.StudentId),
			};
			return View(classroomVM);
		}

		[HttpPost]
		public IActionResult Edit(ClassroomVM classroomVM)
		{
			if (ModelState.IsValid)
			{
				_classroomService.Update(classroomVM.Classroom);
				_classroomService.UpdateFinalGrade(classroomVM.Classroom);
				return RedirectToAction("Detail", new { id = classroomVM.Classroom.SubjectId });
			}
			return View(classroomVM);
		}

		public IActionResult Delete(int id, int subjectId)
		{
			_classroomService.Remove(id);
			return RedirectToAction("Detail", new { id = subjectId });
		}
	}
}
