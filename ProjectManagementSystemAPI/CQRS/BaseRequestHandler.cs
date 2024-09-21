﻿using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS
{
    public abstract class BaseRequestHandler<T,TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>  where T : BaseModel
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;
        public BaseRequestHandler(RequestParameters requestParameters
            ,IRepository<T> repository
            )
        {
            _mediator = requestParameters.Mediator;
            _userState = requestParameters.UserState;
            _repository = repository;

        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
