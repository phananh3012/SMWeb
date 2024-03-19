
using Dapper;
using SMWeb.Data;
using SMWeb.Models;
using System.Data;

namespace SMWeb.Repository
{
	public class ClassroomRepository : IClassroomRepository
	{
		private readonly DapperContext _dapperContext;
		private readonly IDbConnection _connection;

		public ClassroomRepository(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
			_connection = _dapperContext.CreateConnection();
		}

		public Classroom Get(int id)
		{
			var query = "SELECT * FROM Classroom WHERE ClassroomId = @ClassroomId";
			return _connection.QueryFirstOrDefault<Classroom>(query, new { ClassroomId = id });
		}

		public IEnumerable<Classroom> GetBySubject(int SubjectId)
		{
			var query = "SELECT * FROM Classroom WHERE SubjectId = @SubjectId";
			return _connection.Query<Classroom>(query, new { SubjectId }).ToList();
		}

		public void Update(Classroom classroom)
		{
			var query = "UPDATE Classroom SET FirstGrade = @FirstGrade, SecondGrade = @SecondGrade, FinalGrade = @FinalGrade WHERE ClassroomId = @ClassroomId";
			_connection.Execute(query, new { classroom.FirstGrade, classroom.SecondGrade, classroom.FinalGrade, classroom.ClassroomId });
		}

		public void Add(Classroom classroom)
		{
			string query = "INSERT INTO Classroom VALUES(@StudentId, @SubjectId, @FirstGrade, @SecondGrade, @FinalGrade)";
			_connection.Execute(query, new { classroom.StudentId, classroom.SubjectId, classroom.FirstGrade, classroom.SecondGrade, classroom.FinalGrade });
		}

		public void Remove(int ClassroomId)
		{
			string query = "DELETE FROM Classroom WHERE ClassroomId = @ClassroomId";
			_connection.Execute(query, new { ClassroomId });
		}
	}

}
