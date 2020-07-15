using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Web.Features.Command
{
    public class commandBase<T> : IRequest<T> where T : class
    {
    }
}
