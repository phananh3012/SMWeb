
using SMWeb.Models;

namespace SMWeb.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
    }
}
