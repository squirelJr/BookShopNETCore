
using Abstractions.DTO;
using Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Book.Command
{
    public class AddOrUpdateBookCommand : IRequest<bool>
    {
        public BookDTO BookDTO { get; set; }
    }

    public class AddOrUpdateBookCommandHandler : IRequestHandler<AddOrUpdateBookCommand, bool>
    {
        private readonly BooksInMemory _booksInMemory;

        public AddOrUpdateBookCommandHandler()
        {
            _booksInMemory = new BooksInMemory();
        }

        public Task<bool> Handle(AddOrUpdateBookCommand request, CancellationToken cancellationToken)
        {
            var existingProduct =
                _booksInMemory.BookDtos.FirstOrDefault(p => p.Id.Equals(request.BookDTO.Id));

            if (existingProduct != null)
            {
                var index = _booksInMemory.BookDtos.FindIndex(p => p.Id.Equals(request.BookDTO.Id));
                _booksInMemory.BookDtos[index] = request.BookDTO;
                return Task.FromResult(true);
            }

            _booksInMemory.BookDtos.Add(request.BookDTO);
            return Task.FromResult(true);
        }
    }

}
