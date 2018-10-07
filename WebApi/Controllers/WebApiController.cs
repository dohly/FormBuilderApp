using Domain.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public abstract class WebApiController:ControllerBase
    {
        public ISecurityService Guard { get; }
        public Infrastructure.Services.ILogger Log { get; }
        public WebApiController(ISecurityService guard, Infrastructure.Services.ILogger log)
        {
            Guard = guard;
            Log = log;
        }        
        
    }
}
