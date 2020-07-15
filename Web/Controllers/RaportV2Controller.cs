using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModel;
using Web.Features.Command;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/Raport/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class RaportV2Controller : ApiBasedController
    {
        public RaportV2Controller(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Produces("application/json")]
        [ActionName("GetCount")]
        public async Task<ActionResult<VMoutcount>> GetCount([FromQuery] VMParam input)
        {
            return Single(await CommandAsync(new PostDataCount(input.startDate, input.endDate)));
        }
        [HttpGet]
        [Produces("application/json")]
        [ActionName("GetData")]
        public async Task<ActionResult<VMOutData>> GetRaport([FromQuery] VMParam input)
        {
            return Single(await CommandAsync(new PostData(input.startDate, input.endDate)));
        }
    }
}
