using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Web.ViewModel;
using Web.Features.Command;

namespace Web.Controllers
{
    [Route("api/datacount")]
    [ApiController]
    public class GetCountController : ApiBasedController
    {
        public GetCountController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<ActionResult<VMoutcount>> GetCount(VMInCount input)
        {
            return Single(await CommandAsync(new PostDataCount(input.startDate, input.endDate)));
        }
    }
}
