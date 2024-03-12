using SMWeb.Models;

namespace SMWeb.Repository
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Subject Get(int id);
    }
}
