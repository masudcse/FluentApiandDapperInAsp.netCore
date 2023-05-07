using FluentApi.Model;
using FluentApi.Repository;

namespace FluentApi.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }
    }
}
