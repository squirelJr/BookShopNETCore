using Abstractions.DTO;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Query
{
  
    public class GetBookQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly BooksDBContext _dbContext;

        public GetBookQueryHandler(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var Book = await _dbContext.Books.Where(b=>b.IsActive==true).FirstOrDefaultAsync(x =>  x.Id == request.Id, cancellationToken);
            if (Book == null)
            {
                throw new InvalidOperationException("Invalid Book");
            }
            return new BookDTO()
            {
                Author = Book.Author,
                IsActive = Book.IsActive,
                Description = Book.Description,
                Id = Book.Id,
                Title = Book.Title
            };
        }
    }

}
