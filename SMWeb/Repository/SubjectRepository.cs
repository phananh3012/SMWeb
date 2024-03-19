using Dapper;
using SMWeb.Data;
using SMWeb.Models;
using SMWeb.Repository.IRepository;
using System.Data;

namespace SMWeb.Repository
{
    public class SubjectRepository : ISubjectRepository
	{
		private readonly DapperContext _dapperContext;
		private readonly IDbConnection _connection;

		public SubjectRepository(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
			_connection = _dapperContext.CreateConnection();
		}

		public IEnumerable<Subject> GetAll()
		{
			string query = "SELECT * FROM Subject";
			return _connection.Query<Subject>(query).ToList();
		}

		public Subject Get(int id)
		{
			string query = "SELECT * FROM Subject WHERE SubjectId = @SubjectId";
			return _connection.QueryFirstOrDefault<Subject>(query, new { SubjectId = id });
		}

		public void Add(Subject subject)
		{
			string query = "INSERT INTO Subject VALUES(@SubjectName, @NumberOfPeriod, @FirstGradeRate, @SecondGradeRate)";
			_connection.Execute(query, new { subject.SubjectName, subject.NumberOfPeriod, subject.FirstGradeRate, subject.SecondGradeRate });
		}

		public void Update(Subject subject)
		{
			string query = "UPDATE Subject SET SubjectName = @SubjectName, NumberOfPeriod = @NumberOfPeriod, FirstGradeRate = @FirstGradeRate, SecondGradeRate = @SecondGradeRate WHERE SubjectId = @SubjectId";
			_connection.Execute(query, new { subject.SubjectName, subject.NumberOfPeriod, subject.FirstGradeRate, subject.SecondGradeRate, subject.SubjectId });
		}

		public void Remove(int SubjectId)
		{
			string query = "DELETE FROM Subject WHERE SubjectId = @SubjectId";
			_connection.Execute(query, new { SubjectId });
		}
	}
}
