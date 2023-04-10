
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Command
{
    public class DeleteAuthorCommand : IRequest<IEnumerable<bool>>
    {
        public string Author { get; set; }
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, IEnumerable<bool>>
    {
        private readonly BooksInMemory _booksInMemory;

        public DeleteAuthorCommandHandler()
        {
            _booksInMemory = new BooksInMemory();
        }

        public Task<IEnumerable<bool>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var existingAuthors=
                _booksInMemory.BookDtos.Where(p => p.Author.Equals(request.Author)).ToList();

            if (existingAuthors != null)
            {
                var result = existingAuthors.Select(b => { return b.IsActive = false; });
                return Task.FromResult(result);
            }

            throw new InvalidOperationException("Invalid Book");
        }
    }
}
