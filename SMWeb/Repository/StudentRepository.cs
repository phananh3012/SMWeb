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
			using var connection = _dapperContext.CreateConnection();
			return connection.Query<Student>(query).ToList();
		}
		public Student Get(int id)
		{
			string query = "SELECT * FROM Student WHERE StudentId = @StudentId";
			using var connection = _dapperContext.CreateConnection();
			return connection.QueryFirstOrDefault<Student>(query, new { StudentId = id });
		}

		public void Add(Student student)
		{
			string query = "INSERT INTO Student VALUES(@StudentName, @Gender, @DOB, @Class, @Course)";
			using var connection = _dapperContext.CreateConnection();
			connection.Execute(query, new { student.StudentName, student.Gender, student.DOB, student.Class, student.Course });
		}

		public void Update(Student student)
		{
			string query = "UPDATE Student SET StudentName = @StudentName, Gender = @Gender, DOB = @DOB, Class = @Class, Course = @Course WHERE StudentId = @StudentId";
			using var connection = _dapperContext.CreateConnection();
			connection.Execute(query, new { student.StudentName, student.Gender, student.DOB, student.Class, student.Course, student.StudentId });
		}
		public void Remove(int StudentId)
		{
			string query = "DELETE FROM Student WHERE StudentId = @StudentId";
			using var connection = _dapperContext.CreateConnection();
			connection.Execute(query, new { StudentId });
		}
	}
}
