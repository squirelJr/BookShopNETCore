using Abstractions.DTO;
using Domain;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Query
{
    public class GetBooksQuery: IRequest<List<BookDTO>> {
        public int RowIndex { get; set; } = 1;
        public int Count { get; set; } = 10;
    }

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDTO>>
    {
        private readonly BooksInMemory _booksInMemory;

        public GetBooksQueryHandler()
        {
            _booksInMemory = new BooksInMemory();
        }

        public Task<List<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var products = _booksInMemory.BookDtos.Where(x=>x.IsActive==true).ToList().Skip((request.RowIndex - 1) * request.Count).Take(request.Count).ToList(); 

            return Task.FromResult(products);
        }
    }
}
