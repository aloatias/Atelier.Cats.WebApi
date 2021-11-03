﻿using Atelier.Cats.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Atelier.Cats.Infrastructure.Presentation.Controllers
{
    public class AtelierControllerBase<TController> : ControllerBase
    {
        protected ILogger<TController> Logger { get; private set; }

        public AtelierControllerBase(
            ILogger<TController> logger)
        {
            Logger = logger;
        }

        protected IActionResult SendResponse(IAtelierResponse response)
        {
            switch (response.Status)
            {
                case HttpStatusCode.OK:
                    return Ok();
                case HttpStatusCode.BadRequest:
                    return BadRequest(response.ErrorMessage);
                case HttpStatusCode.NoContent:
                    return NoContent();
                default:
                    return StatusCode((int)HttpStatusCode.InternalServerError, "An error has occurred. Please try again later");
            }
        }

        protected IActionResult SendResponse<TEntity>(IAtelierResponse<TEntity> response)
        {
            switch (response.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(response.Content);
                case HttpStatusCode.Created:
                    return Created(response.ResourceUrl, response.Content);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response.ErrorMessage);
                case HttpStatusCode.NoContent:
                    return NoContent();
                default:
                    return StatusCode((int)HttpStatusCode.InternalServerError, "An error has occurred. Please try again later");
            }
        }
    }
}