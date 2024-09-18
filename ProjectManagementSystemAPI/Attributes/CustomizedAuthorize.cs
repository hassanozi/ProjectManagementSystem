using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectManagementSystemAPI.CQRS.RoleFeatures.Queries;
using ProjectManagementSystemAPI.Enum;

namespace ProjectManagementSystemAPI.Filters
{
    public class CustomizedAuthorize : ActionFilterAttribute
    {
        private readonly Feature _feature;
        private readonly IMediator _mediator;

        public CustomizedAuthorize(Feature feature, IMediator mediator)
        {
            _feature = feature;
            _mediator = mediator;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var loggedUser = context.HttpContext.User;

            var roleID = loggedUser.FindFirst("RoleID");

            if (roleID is null || string.IsNullOrEmpty(roleID.Value))
            {
                throw new UnauthorizedAccessException();
            }

            var query = new CheckRoleFeatureAccessQuery(int.Parse(roleID.Value), _feature);
            bool hasAccess = await _mediator.Send(query);

            if (!hasAccess)
            {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(context);
        }
    }
}
