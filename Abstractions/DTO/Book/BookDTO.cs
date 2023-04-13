using FluentValidation;
namespace Abstractions.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    internal class BookDtoRequestValidation : AbstractValidator<BookDTO>
    {
        public BookDtoRequestValidation()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100); ;
            RuleFor(x => x.Description).NotEmpty();
        }
    }


}
