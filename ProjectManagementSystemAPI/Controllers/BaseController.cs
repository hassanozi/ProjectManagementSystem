﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.DTOs;
using System.Security.Claims;

namespace ProjectManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;
        public BaseController(ControllereParameters controllereParameters)
        {
            _mediator = controllereParameters.Mediator;
            _userState = controllereParameters.UserState;

            var loggedUser = new HttpContextAccessor().HttpContext.User;

            _userState.Role = loggedUser?.FindFirst("RoleID")?.Value ?? "";
            _userState.ID = loggedUser?.FindFirst("ID")?.Value ?? "";
            _userState.Name = loggedUser?.FindFirst(ClaimTypes.Name)?.Value ?? "";
        }
    }
}
