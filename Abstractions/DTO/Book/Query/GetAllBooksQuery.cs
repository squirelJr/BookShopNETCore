using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.DTO
{
    public class GetAllBooksQuery:IRequest<IEnumerable<BookDTO>> {
        public int RowIndex { get; set; } = 1;
        public int Count { get; set; } = 10;
    
    }


    public class GetAllBooksQueryValidation : AbstractValidator<GetAllBooksQuery>
    {
        public GetAllBooksQueryValidation()
        {
            RuleFor(x => x.RowIndex).GreaterThan(0).WithMessage("Row Index Can not be less then 1");
            
        }
    }
}
