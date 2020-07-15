using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Web.ViewModel;
using Web.Features.Command;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/Raport/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RaportController : ApiBasedController
    {
        public RaportController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Produces("application/json")]
        [ActionName("GetCount")]
        public async Task<ActionResult<VMoutcount>> GetCount([FromQuery]VMInCount input)
        {
            return Single(await CommandAsync(new PostDataCount(input.startDate, input.endDate)));
        }
        [HttpGet]
        [Produces("application/json")]
        [ActionName("GetData")]
        public async Task<ActionResult<VMOutData>> GetRaport([FromQuery]VMInData input)
        {
            return Single(await CommandAsync(new PostDataRaport(input.startDate, input.endDate, input.startNo, input.endNo)));
        }
    }
}
