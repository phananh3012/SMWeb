using Microsoft.AspNetCore.Mvc;
using SMWeb.Models;
using SMWeb.Repository;

namespace SMWeb.Controllers
{
	public class SubjectController : Controller
	{
		private readonly ISubjectRepository _subjectRepository;
		public SubjectController(ISubjectRepository subjectRepository)
		{
			_subjectRepository = subjectRepository;
		}
		public IActionResult Index()
		{
			var subjectList = _subjectRepository.GetAll();
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
			if (ModelState.IsValid)
			{
				_subjectRepository.Add(subject);
				return RedirectToAction("Index");
			}

			return View();
		}
		public IActionResult Edit(int id)
		{
			Subject subject = _subjectRepository.Get(id);
			if (subject == null)
			{
				return NotFound();
			}
			return View(subject);
		}
		[HttpPost]
		public IActionResult Edit(Subject subject)
		{
			if (ModelState.IsValid)
			{
				_subjectRepository.Update(subject);
				return RedirectToAction("Index");
			}
			return View(subject);
		}
		public IActionResult Delete(int id)
		{
			_subjectRepository.Remove(id);
			return RedirectToAction("Index");
		}

	}
}
