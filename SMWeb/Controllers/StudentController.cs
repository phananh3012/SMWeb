using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMWeb.Models;
using SMWeb.Repository;

namespace SMWeb.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentRepository _studentRepo;
		public StudentController(IStudentRepository studentRepo)
		{
			_studentRepo = studentRepo;
		}
		public IActionResult Index()
		{
			var studentList = _studentRepo.GetAll();
			if (studentList == null)
			{
				return NotFound();
			}
			return View(studentList);
		}
		public IActionResult Create()
		{
			List<SelectListItem> GenderList = new()
			{
				new SelectListItem() { Text = "Nam", Value = "1" },
				new SelectListItem() { Text = "Nữ", Value = "2" },
				new SelectListItem() { Text = "Khác", Value = "0" }
			};
			ViewBag.GenderList = GenderList;
			return View();
		}
		[HttpPost]
		public IActionResult Create(Student student)
		{
			if (ModelState.IsValid)
			{
				_studentRepo.Add(student);
				return RedirectToAction("Index");
			}
			List<SelectListItem> GenderList = new()
			{
				new SelectListItem() { Text = "Nam", Value = "1" },
				new SelectListItem() { Text = "Nữ", Value = "2" },
				new SelectListItem() { Text = "Khác", Value = "0" }
			};
			ViewBag.GenderList = GenderList;
			return View();
		}
		public IActionResult Edit(int id)
		{
			Student student = _studentRepo.Get(id);
			if (student == null)
			{
				return NotFound();
			}
			List<SelectListItem> GenderList = new()
			{
				new SelectListItem() { Text = "Nam", Value = "1" },
				new SelectListItem() { Text = "Nữ", Value = "2" },
				new SelectListItem() { Text = "Khác", Value = "0" }
			};
			ViewBag.GenderList = GenderList;
			return View(student);
		}
		[HttpPost]
		public IActionResult Edit(Student student)
		{
			if (ModelState.IsValid)
			{
				_studentRepo.Update(student);
				return RedirectToAction("Index");
			}
			List<SelectListItem> GenderList = new()
			{
				new SelectListItem() { Text = "Nam", Value = "1" },
				new SelectListItem() { Text = "Nữ", Value = "2" },
				new SelectListItem() { Text = "Khác", Value = "0" }
			};
			ViewBag.GenderList = GenderList;
			return View(student);
		}
		public IActionResult Delete(int id)
		{
			_studentRepo.Remove(id);
			return RedirectToAction("Index");
		}
	}
}
