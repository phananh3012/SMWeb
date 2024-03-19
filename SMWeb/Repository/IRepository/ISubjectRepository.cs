using SMWeb.Models;

namespace SMWeb.Repository.IRepository
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Subject Get(int id);
        void Add(Subject subject);
        void Update(Subject subject);
        void Remove(int id);
    }
}
