using Microsoft.AspNetCore.Mvc.Filters;
using ProjectManagementSystemAPI.Constants.Enum;
using ProjectManagementSystemAPI.Services;

namespace ProjectManagementSystemAPI.Filters
{
    public class CustomizedAuthorize : ActionFilterAttribute
    {
        private readonly Feature _feature;
        private readonly IRoleFeatureService _roleFeatureService;

        public CustomizedAuthorize(Feature feature, IRoleFeatureService roleFeatureService)
        {
            _feature = feature;
            _roleFeatureService = roleFeatureService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var loggedUser = context.HttpContext.User;

            var roleID = loggedUser.FindFirst("RoleID");

            if (roleID is null || string.IsNullOrEmpty(roleID.Value))
            {
                throw new UnauthorizedAccessException();
            }

            bool hasAccess = _roleFeatureService.HasAccess(int.Parse(roleID.Value), _feature);

            if (!hasAccess)
            {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(context);
        }
    }
}
