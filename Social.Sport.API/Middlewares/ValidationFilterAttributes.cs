using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Social.Sport.API.Helper;
using Social.Sport.Core.Constants;

namespace Social.Sport.API.Middlewares
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorList = ValidationErrors(context);
                var errorDetails = new ErrorResult(ConstantConfig.ValidationMessages.Messagevalid, errorList);
                context.Result = new BadRequestObjectResult(errorDetails);
            }
        }

        private List<Error> ValidationErrors(ActionExecutingContext context)
        {
            return context.ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                ).Select(x => new Error(x.Key, string.Join(',', value: x.Value))).ToList();
        }
    }
}
