using FluentApi.Model;
using FluentApi.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FluentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IValidator<Student> _validator;
        private readonly IStudentService _studentService;
        public StudentController(IValidator<Student> validator,IStudentService studentService)
        {
            _validator = validator;
            _studentService = studentService;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            var validationResult = await _validator.ValidateAsync(student);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
            .GroupBy(x => x.PropertyName, x => x.ErrorMessage)
            .ToDictionary(x => x.Key, x => x.ToArray());
                return ValidationProblem(new ValidationProblemDetails(errors));

            }

            _studentService.AddStudent(student);
            return NoContent();
        }
    }
}