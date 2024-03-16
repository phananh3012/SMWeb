using Microsoft.AspNetCore.Mvc;
using SMWeb.Models;
using SMWeb.Service;

namespace SMWeb.Controllers
{
	public class SubjectController : Controller
	{
		private readonly ISubjectService _subjectService;
		public SubjectController(ISubjectService subjectService)
		{
			_subjectService = subjectService;
		}
		public IActionResult Index()
		{
			var subjectList = _subjectService.GetAll();
			if (subjectList == null)
			{
				return NotFound();
			}
			return View(subjectList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Subject subject)
		{
			if (subject.FirstGradeRate + subject.SecondGradeRate != 1)
			{
				ModelState.AddModelError("Ratio", "Tỉ lệ điểm không đúng");
			}
			if (ModelState.IsValid)
			{
				_subjectService.Add(subject);
				return RedirectToAction("Index");
			}

			return View();
		}
		public IActionResult Edit(int id)
		{
			Subject subject = _subjectService.Get(id);
			if (subject == null)
			{
				return NotFound();
			}
			return View(subject);
		}
		[HttpPost]
		public IActionResult Edit(Subject subject)
		{
			if (subject.FirstGradeRate + subject.SecondGradeRate != 1)
			{
				ModelState.AddModelError("Ratio", "Tỉ lệ điểm không đúng");
			}
			if (ModelState.IsValid)
			{
				_subjectService.Update(subject);
				return RedirectToAction("Index");
			}
			return View(subject);
		}
		public IActionResult Delete(int id)
		{
			_subjectService.Remove(id);
			return RedirectToAction("Index");
		}

	}
}
