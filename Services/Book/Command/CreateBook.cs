using Abstractions.DTO;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Command
{
    public class CreateBook
    {
        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDTO>
        {
            private readonly BooksDBContext _dbContext;

            public CreateBookCommandHandler(BooksDBContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BookDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                var book = new Domain.Entities.Books.Book()
               {
                    Author = request.Author,
                    IsActive=true,
                    Description= request.Description,
                    Title = request.Title,
               };
                await _dbContext.Books.AddAsync(book);
                await _dbContext.SaveChangesAsync();
                return new BookDTO {
                    Title = book.Title,
                    Author = book.Author,
                    IsActive = true,
                    Description= book.Description,
                    Id = book.Id,
                };
            }
        }
    }
}
