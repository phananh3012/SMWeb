using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMWeb.Models;
using SMWeb.Service.IService;

namespace SMWeb.Controllers
{
    public class StudentController : Controller
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		public IActionResult Index()
		{
			var studentList = _studentService.GetAll();
			if (studentList == null)
			{
				return NotFound();
			}
			return View(studentList);
		}

		public IActionResult Create()
		{
			List<SelectListItem> GenderListItem = _studentService.GenderListItem();
			ViewBag.GenderList = GenderListItem;
			return View();
		}

		[HttpPost]
		public IActionResult Create(Student student)
		{
			if (ModelState.IsValid)
			{
				_studentService.Add(student);
				return RedirectToAction("Index");
			}
			List<SelectListItem> GenderListItem = _studentService.GenderListItem();
			ViewBag.GenderList = GenderListItem;
			return View();
		}

		public IActionResult Edit(int id)
		{
			Student student = _studentService.Get(id);
			if (student == null)
			{
				return NotFound();
			}
			List<SelectListItem> GenderListItem = _studentService.GenderListItem();
			ViewBag.GenderList = GenderListItem;
			return View(student);
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{
			if (ModelState.IsValid)
			{
				_studentService.Update(student);
				return RedirectToAction("Index");
			}
			List<SelectListItem> GenderListItem = _studentService.GenderListItem();
			ViewBag.GenderList = GenderListItem;
			return View(student);
		}

		public IActionResult Delete(int id)
		{
			_studentService.Remove(id);
			return RedirectToAction("Index");
		}
	}
}
