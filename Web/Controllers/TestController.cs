using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Interface;
using Web.Factory;
using Web.ViewModel;
using Web.Helper;

namespace Web.Controllers
{
    [Route("api/Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IAppConfig _appCfg;
        public TestController(IAppConfig appCfg)
        {
            _appCfg = appCfg;
            URLStatic.APIClientURL = _appCfg.GetData().URLSource;
        }
        [HttpPost]
        public async Task<IActionResult> SaveRaport(RaportInputCount input)
        {
            var intResponse = await ApiClientFactory.Instance.PostReport<VMoutcount, RaportInputCount>(input);
            return Ok(intResponse);
        }
    }
}