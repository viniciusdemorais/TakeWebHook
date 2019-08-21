using Lime.Protocol;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using take.webhook.business;
using take.webhook.core.Contract.Business;
using take.webhook.core.DTO.Entities;

namespace take.webhook.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHookController : Controller
    {
        readonly IWebHookBll _webHookBll;

        public WebHookController()
        {
            _webHookBll = new WebHookBll();
        }

        [HttpPost]
        public IActionResult SaveBruteData([FromBody]Message data)
        {

            return Json(_webHookBll.Save(new DadoBrutoDTO() { Dado = JsonConvert.SerializeObject(data) }));
        }
    }
}