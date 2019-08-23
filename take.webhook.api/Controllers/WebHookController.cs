using Lime.Protocol.Serialization.Newtonsoft;
using Microsoft.AspNetCore.Mvc;
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
        //readonly JsonNetSerializer _jsonNetSerializer;
        public WebHookController()
        {
            _webHookBll = new WebHookBll();
            //_jsonNetSerializer = new JsonNetSerializer();
        }

        [HttpPost]
        public IActionResult SaveBruteData([FromBody]RespostaWebHookDTO data)
        {
            return Json(_webHookBll.SaveRespostaWebHook(data));
        }
    }
}