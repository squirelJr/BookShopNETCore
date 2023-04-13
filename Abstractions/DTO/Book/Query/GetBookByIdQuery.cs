using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.DTO
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        [Required]
        public long Id { get; set; }
    }
}
