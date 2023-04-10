using Abstractions.DTO;
using Services.Book.Command;
using Services.Book.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Book.Notify;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("book")]
        public async Task<IActionResult> Get(long bookID)
        {
            var result = await _mediator.Send(new GetBookQuery() { BookId = bookID });
            return Ok(result);
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetAll([FromQuery]int pageIndex,int rowCount)
        {
            var result = await _mediator.Send(new GetBooksQuery() { Count=rowCount,RowIndex=pageIndex});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Create product
            var result = await _mediator.Send(new AddOrUpdateBookCommand() { BookDTO = book });

            // Notify consumers
            await _mediator.Publish(new PublishBookNotify() { Message = $"Book {book.Id} created" });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookDTO BookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Update product
            var result = await _mediator.Send(new AddOrUpdateBookCommand() { BookDTO = BookDTO });

            // Notify consumers
            await _mediator.Publish(new PublishBookNotify() { Message = $"Book {BookDTO.Id} updated" });

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(long BookID)
        {
            // Remove product
            var result = await _mediator.Send(new DeleteBookCommand() { BookID = BookID });

            // Notify consumers
            await _mediator.Publish(new PublishBookNotify() { Message = $"Book {BookID} removed" });

            return Ok(result);
        }


        [HttpDelete]
        [Route("RemoveAuthor")]
        public async Task<IActionResult> RemoveAuthor(string Author)
        {
            // Remove product
            var result = await _mediator.Send(new DeleteAuthorCommand() { Author = Author });

            // Notify consumers
            await _mediator.Publish(new PublishBookNotify() { Message = $"Author {Author} removed" });

            return Ok(result);
        }


        [HttpPost("notify")]
        public async Task<IActionResult> NotifyAsync(string message)
        {
            await _mediator.Publish(new PublishBookNotify() { Message = message });
            return Ok();
        }


    }
}
