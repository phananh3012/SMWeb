using Microsoft.AspNetCore.Mvc;
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
    }
}
