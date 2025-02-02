﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBasedController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApiBasedController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await _mediator.Send(query);
        }
        protected ActionResult<T> Single<T>(T data)
        {
            if (data == null) return NotFound();
            return Ok(data);
        }
        protected ActionResult<IEnumerable<T>> List<T>(IEnumerable<T> data)
        {
            if (data == null) return NotFound();
            return Ok(data);
        }
        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await _mediator.Send(command);
        }
    }
}