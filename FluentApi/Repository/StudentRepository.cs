using Dapper;
using FluentApi.Data;
using FluentApi.Model;

namespace FluentApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _dapperContext;
        public StudentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public void AddStudent(Student student)
        {
            string sql = "INSERT INTO Student (Name, Age, Salary) VALUES (@Name, @Age, @Salary); SELECT SCOPE_IDENTITY();";

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = connection.ExecuteScalar<int>(sql, new { student.Name, student.Age, student.Salary });
                student.Id = id;
            }
        }
    }
}
