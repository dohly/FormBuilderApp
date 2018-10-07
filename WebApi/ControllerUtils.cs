using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApi
{
    public static class ControllerUtils
    {
        public static async Task<IActionResult> SafeExecute<TController>(this TController controller, Func<User,Task<IActionResult>> action)
            where TController : WebApiController
        {
            try
            {
                var currentUser = await controller.Guard.GetUserByName(controller.User.Identity.Name);
                return await action(currentUser);
            }
            catch (Exception ex)
            {
                controller.Log.Error(ex);                
                switch (ex)
                {                    
                    case UnauthorizedAccessException ue:
                        return controller.Unauthorized();
                    case NotFoundException nf:
                        return controller.NotFound();
                    case ValidationException ve:
                        return controller.BadRequest(ve.Error);
                    default:
                        return controller.StatusCode(500, ex.Message);
                }
            }
        }
    }
}
