
using Abstractions.DTO;
using Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Command
{
    

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDTO>
    {
        private readonly BooksDBContext _dbContext;

        public UpdateBookCommandHandler(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookDTO?> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.FirstOrDefault(p => p.Id == request.Id);

            if (book is null)
                return default;
          
            book.Description = request.Description;
            book.Title = request.Title;
            book.Author = request.Author;



            await _dbContext.SaveChangesAsync();
            return new BookDTO
            {
                Title = book.Title,
                Author = book.Author,
                IsActive = true,
                Description = book.Description,
                Id = book.Id,
            };
        }
    }

}
