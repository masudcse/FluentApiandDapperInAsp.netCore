using FluentApi.Model;
using FluentValidation;

namespace FluentApi.Validation
{
    public class StudentValidator:AbstractValidator<Student>
    {
        public StudentValidator()
        {
          //  RuleFor(x=>x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).MinimumLength(15);
            RuleFor(x => x.Age).NotNull().InclusiveBetween(18, 55);
            RuleFor(x => x.Salary).NotNull().GreaterThanOrEqualTo(8000);
            
        }

    }
}
