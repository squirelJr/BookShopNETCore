using Abstractions.DTO;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Query
{
    public class GetBookQuery:IRequest<BookDTO>
    {
        public long BookId { get; set; }    
    }


    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDTO>
    {
        private readonly BooksInMemory _BooksInMemory;

        public GetBookQueryHandler()
        {
            _BooksInMemory = new BooksInMemory();
        }

        public Task<BookDTO> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var Book = _BooksInMemory.BookDtos.Where(x => x.IsActive = true).FirstOrDefault(p =>  p.Id.Equals(request.BookId));
            if (Book == null)
            {
                throw new InvalidOperationException("Invalid Book");
            }

            return Task.FromResult(Book);
        }
    }

}
