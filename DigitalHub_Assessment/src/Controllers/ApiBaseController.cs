using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiBaseController : ControllerBase
    {
    }
}
