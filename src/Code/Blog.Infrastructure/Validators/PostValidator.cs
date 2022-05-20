using FluentValidation;

using Blog.Core.DTO;

namespace Blog.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDTO>
    {
        public PostValidator()
        {
            RuleFor(x => x.AuthorId).Cascade(CascadeMode.Stop)
                                    .NotNull().WithMessage("AuthorId is required");
            RuleFor(x => x.Title).Cascade(CascadeMode.Stop)
                                    .NotNull().WithMessage("Title cannot be null")
                                    .NotEmpty().WithMessage("Title cannot be empty")
                                    .Length(1, 100).WithMessage("Title must be between 1 and 100 characters");
            RuleFor(x => x.MetaTitle).MaximumLength(100).WithMessage("MetaTitle must be less than 100 characters");
            RuleFor(x => x.Slug).Cascade(CascadeMode.Stop)
                                    .NotNull().WithMessage("Slug cannot be null")
                                    .NotEmpty().WithMessage("Slug cannot be empty")
                                    .Length(1, 100).WithMessage("Slug must be between 1 and 100 characters");
            RuleFor(x => x.Summary).Cascade(CascadeMode.Stop)
                                    .MaximumLength(500).WithMessage("Summary must be less than 500 characters");
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}