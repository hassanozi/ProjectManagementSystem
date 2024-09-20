﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.Projects.Commands;
using ProjectManagementSystemAPI.CQRS.Projects.Queries;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.ViewModels;
using ProjectManagementSystemAPI.ViewModels.ProjectViewModels;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseViewModel> CreateProject(AddProjectViewModel viewModel)
        {
            var projectDTO = viewModel.MapOne<AddProjectDTO>();
            var command = new AddProjectCommand(projectDTO);
            var result = await _mediator.Send(command);
            return ResponseViewModel.Success(result);
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel> GetSingleProject(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery(id));
            var mappedProject = project.MapOne<ProjectViewModel>();
            return ResponseViewModel.Success(mappedProject);
        }
        
        [HttpGet]
        public async Task<ResponseViewModel> GetProjectsList()
        {
            var projects = await _mediator.Send(new GetProjectsListQuery());
            var mappedProjects = projects.Select(x => x.MapOne<ProjectViewModel>());
            return ResponseViewModel.Success(mappedProjects);
        }
    }
}
