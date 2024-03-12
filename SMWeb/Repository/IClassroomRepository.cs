using SMWeb.Models;

namespace SMWeb.Repository
{
    public interface IClassroomRepository
    {
        IEnumerable<Classroom> GetAll();
        Classroom Get(int id);
        void Update(Classroom classroom);
        void UpdateFinalGrade(double firstGradeRate, double secondGradeRate, int id);


    }
}
