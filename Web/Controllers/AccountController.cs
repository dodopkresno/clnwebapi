using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Interface;
using Web.ViewModel;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppConfig _appCfg;
        public AccountController(IAppConfig appCfg)
        {
            _appCfg = appCfg;
        }

        /// <summary>
        /// Generate Bearer Token API.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Data Account.</returns>
        /// <response code="401"> Access Unauthorized</response>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _appCfg.Authenticate(model.username, model.password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
