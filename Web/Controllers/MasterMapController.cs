using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Web.ViewModel;
using Web.Features.Queries;
using Web.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/master")]
    [ApiController]
    public class MasterMapController : ApiBasedController
    {
        private readonly IAppConfig _appCfg;
        public MasterMapController(IMediator mediator, IAppConfig appCfg) : base(mediator)
        {
            _appCfg = appCfg;
        }

        /// <summary>
        /// Menampilkan Mapping COA PT TPS
        /// </summary>
        /// <returns>Data Mapping</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VMCoaMap>>> MyMapMaster()
        {
            return List(await QueryAsync(new GetCOAMap(_appCfg.GetData().JSONDataLocation)));
        }
    }
}