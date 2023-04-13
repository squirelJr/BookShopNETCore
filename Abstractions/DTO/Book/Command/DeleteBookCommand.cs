using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.DTO
{
    public  class DeleteBookCommand :IRequest<BookDTO>
    {
        public long Id { get; set; }
    }
}
