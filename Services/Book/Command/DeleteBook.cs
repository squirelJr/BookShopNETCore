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
    public class DeleteBookCommand : IRequest<bool>
    {
        public long BookID { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly BooksInMemory _booksInMemory;

        public DeleteBookCommandHandler()
        {
            _booksInMemory = new BooksInMemory();
        }

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook =
                _booksInMemory.BookDtos.FirstOrDefault(p => p.Id.Equals(request.BookID));

            if (existingBook != null)
            {
                var result = existingBook.IsActive = false;
                return Task.FromResult(result);
            }

            throw new InvalidOperationException("Invalid book");
        }
    }


}
