﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.DTO
{
    public  class CreateBookCommand:IRequest<BookDTO>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

    }

  
}
