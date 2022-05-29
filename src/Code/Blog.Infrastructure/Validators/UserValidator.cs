using FluentValidation;

using Blog.Core.DTO;

namespace Blog.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            // RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
            //                     .NotNull().WithMessage("Email is required")
            //                     .NotEmpty().WithMessage("Email cannot be empty")
            //                     .EmailAddress().WithMessage("Email must be a valid email address");
            RuleFor(x => x.Username).Cascade(CascadeMode.Stop)
                                    .NotNull().WithMessage("Username is required")
                                    .NotEmpty().WithMessage("Username cannot be empty")
                                    .Length(1, 100).WithMessage("Username must be between 1 and 100 characters");
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                                        .NotNull().WithMessage("PasswordHash is required")
                                        .NotEmpty().WithMessage("PasswordHash cannot be empty")
                                        .Length(1, 100).WithMessage("PasswordHash must be between 1 and 100 characters");
        }
    }
}