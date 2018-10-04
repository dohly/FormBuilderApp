using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi
{
    public static class ControllerUtils
    {
        public static async Task<IActionResult> SafeExecute<TController>(this TController controller, Func<Task<IActionResult>> action)
            where TController : ControllerBase
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                // TODO add logging
                switch (ex)
                {                    
                    case UnauthorizedAccessException ue:
                        return controller.Unauthorized();
                    default:
                        return controller.StatusCode(500, ex.Message);
                }
            }
        }
    }
}
