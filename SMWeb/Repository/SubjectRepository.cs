using Dapper;
using SMWeb.Data;
using SMWeb.Models;

namespace SMWeb.Repository
{
	public class SubjectRepository : ISubjectRepository
	{
		private readonly DapperContext _dapperContext;
		public SubjectRepository(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}
		public IEnumerable<Subject> GetAll()
		{
			string query = "SELECT * FROM Subject";
			using var connection = _dapperContext.CreateConnection();
			return connection.Query<Subject>(query).ToList();
		}
		public Subject Get(int id)
		{
			string query = "SELECT * FROM Subject WHERE SubjectId = @SubjectId";
			using var connection = _dapperContext.CreateConnection();
			return connection.QueryFirstOrDefault<Subject>(query, new { SubjectId = id });
		}
		public void Add(Subject subject)
		{
			string query = "INSERT INTO Subject VALUES(@SubjectName, @NumberOfPeriod, @FirstGradeRate, @SecondGradeRate)";
			using var connection = _dapperContext.CreateConnection();
			connection.Execute(query, new { subject.SubjectName, subject.NumberOfPeriod, subject.FirstGradeRate, subject.SecondGradeRate });
		}

		public void Update(Subject subject)
		{
			string query = "UPDATE Subject SET SubjectName = @SubjectName, NumberOfPeriod = @NumberOfPeriod, FirstGradeRate = @FirstGradeRate, SecondGradeRate = @SecondGradeRate WHERE SubjectId = @SubjectId";
			using var connection = _dapperContext.CreateConnection();
			connection.Execute(query, new { subject.SubjectName, subject.NumberOfPeriod, subject.FirstGradeRate, subject.SecondGradeRate, subject.SubjectId });
		}
		public void Remove(int SubjectId)
		{
			string query = "DELETE FROM Subject WHERE SubjectId = @SubjectId";
			using var connection = _dapperContext.CreateConnection();
			connection.Execute(query, new { SubjectId });
		}
	}
}
