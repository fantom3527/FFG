using Microsoft.AspNetCore.Mvc;

namespace FFG.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController<TService> : ControllerBase
    {
        private TService? _service;
        protected TService Service => _service ??= HttpContext.RequestServices.GetService<TService>()
                                                   ?? throw new Exception("Cannot instantiate service");
    }
}
