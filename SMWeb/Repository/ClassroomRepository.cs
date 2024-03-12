
using Dapper;
using SMWeb.Data;
using SMWeb.Models;

namespace SMWeb.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly DapperContext _dapperContext;
        public ClassroomRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public IEnumerable<Classroom> GetAll()
        {
            var query = "SELECT * FROM Classroom";
            using (var connection = _dapperContext.CreateConnection())
            {
                return connection.Query<Classroom>(query).ToList();
            }
        }
        public Classroom Get(int id)
        {
            var query = "SELECT * FROM Classroom WHERE ClassroomId = @ClassroomId";
            using (var connection = _dapperContext.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Classroom>(query, new { ClassroomId = id });
            }
        }

        public void Update(Classroom classroom)
        {
            var query = "UPDATE Classroom SET FirstGrade = @FirstGrade, SecondGrade = @SecondGrade WHERE ClassroomId = @ClassroomId";


            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, new { FirstGrade = classroom.FirstGrade, SecondGrade = classroom.SecondGrade, ClassroomId = classroom.ClassroomId });
            }
        }

        public void UpdateFinalGrade(double firstGradeRate, double secondGradeRate, int ClassroomId)
        {
            string updateQuery = "UPDATE Classroom SET FinalGrade = FirstGrade * @firstGradeRate + SecondGrade * @secondGradeRate where ClassroomId = @ClassroomId";
            string updateQuery1 = "UPDATE Classroom SET Result = CASE WHEN FinalGrade > = 4 THEN 'Do' WHEN FinalGrade < 4 THEN 'Truot' ELSE null END";
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(updateQuery, new { firstGradeRate, secondGradeRate, ClassroomId });
                connection.Execute(updateQuery1);
            }
        }
    }

}
