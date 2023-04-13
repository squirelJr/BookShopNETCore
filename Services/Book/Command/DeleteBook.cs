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

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BookDTO>
    {
        private readonly BooksDBContext _dbContext;

        public DeleteBookCommandHandler(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookDTO> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook =
                _dbContext.Books.FirstOrDefault(p => p.Id.Equals(request.Id));

            if (existingBook != null)
            {
                var result = existingBook.IsActive = false;
                await _dbContext.SaveChangesAsync();
                return new BookDTO
                {
                    Id =existingBook.Id,
                    Author = existingBook.Author,
                    IsActive = existingBook.IsActive,
                    Description = existingBook.Description,
                    Title= existingBook.Title,
                };
            }

            throw new InvalidOperationException("Invalid book");
        }
    }


}
