using Domain.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public abstract class WebApiController:ControllerBase
    {
        public ISecurityService Guard { get; }
        public WebApiController(ISecurityService guard)
        {
            Guard = guard;
        }        
        
    }
}
