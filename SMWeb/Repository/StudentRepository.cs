using Dapper;
using SMWeb.Data;
using SMWeb.Models;

namespace SMWeb.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _dapperContext;
        public StudentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public IEnumerable<Student> GetAll()
        {
            var query = "SELECT * FROM Student";
            using (var connection = _dapperContext.CreateConnection())
            {
                return connection.Query<Student>(query).ToList();
            }
        }
        public Student Get(int id)
        {
            string query = "SELECT * FROM Student WHERE StudentId = @StudentId";
            using (var connection = _dapperContext.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Student>(query, new { StudentId = id });
            }
        }
    }
}
