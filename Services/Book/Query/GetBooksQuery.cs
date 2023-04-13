using Abstractions.DTO;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Query
{
    public class GetBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly BooksDBContext _dbContext;

        public GetBooksQueryHandler(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {

            var books = await _dbContext.Books.Where(b => b.IsActive == true).Skip((request.RowIndex - 1) * request.Count).Take(request.Count).Where(x=>x.IsActive==true).ToListAsync();

            return books.Select(x => new BookDTO()
            {
                Author = x.Author,
                IsActive = x.IsActive,
                Description = x.Description,
                Id = x.Id,
                Title = x.Title,
            });
        }
    }
}
