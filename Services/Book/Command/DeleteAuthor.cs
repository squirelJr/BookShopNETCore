
using Abstractions.DTO;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Command
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand,bool>
    {
        private readonly BooksDBContext _dbContext;

        public DeleteAuthorCommandHandler(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var existingAuthors=
                _dbContext.Books.Where(p => p.Author.Equals(request.Author)).ToList();

            if (existingAuthors != null)
            {
                var result =  existingAuthors.Select(b => { return b.IsActive = false; });
                await _dbContext.SaveChangesAsync();
                return true;
            }

            throw new InvalidOperationException("Invalid Author");
        }
    }
}
