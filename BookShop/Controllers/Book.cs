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
        public async Task<IActionResult> Get([FromQuery] GetBookByIdQuery bookId)
        {
            var result = await _mediator.Send(bookId);
            return Ok(result);
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetAll([FromQuery]GetAllBooksQuery request)
        {
            var validator = new GetAllBooksQueryValidation();
            var isValid =  validator.Validate(request);
            if (!isValid.IsValid)
            {
                return BadRequest(isValid.Errors);
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Create product
            var result = await _mediator.Send(book);

            // Notify consumers
            await _mediator.Publish(new PublishBookNotify() { Message = $"Book {result.Id} created" });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Update product
            var result = await _mediator.Send(request);

            // Notify consumers
            await _mediator.Publish(new PublishBookNotify() { Message = $"Book {result.Id} updated" });

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(DeleteBookCommand request)
        {
            // Remove product
            var result = await _mediator.Send(request);

            // Notify consumers
            await _mediator.Publish(new PublishBookNotify() { Message = $"Book {result.Id} removed" });

            return Ok(result);
        }


        [HttpDelete]
        [Route("RemoveAuthor")]
        public async Task<IActionResult> RemoveAuthor(DeleteAuthorCommand request)
        {
            // Remove product
            var result = await _mediator.Send(request);

            // Notify consumers
            await _mediator.Publish(new PublishBookNotify() { Message = $"Author {request.Author} removed" });

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
