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
		public Subject Get(int id)
		{
			string query = "SELECT * FROM Subject WHERE SubjectId = @SubjectId";
			using (var connection = _dapperContext.CreateConnection())
			{
				return connection.QueryFirstOrDefault<Subject>(query, new { SubjectId = id });
			}
		}
		public IEnumerable<Subject> GetAll()
		{
			string query = "SELECT * FROM Subject";
			using (var connection = _dapperContext.CreateConnection())
			{
				return connection.Query<Subject>(query).ToList();
			}
		}
	}
}
