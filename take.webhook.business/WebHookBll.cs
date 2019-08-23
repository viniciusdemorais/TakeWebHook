using take.webhook.core.Contract.Business;
using take.webhook.core.Contract.Repositories;
using take.webhook.core.DTO;
using take.webhook.core.DTO.Entities;
using take.webhook.repository;

namespace take.webhook.business
{
    public class WebHookBll : IWebHookBll
    {
        readonly IWebHookRepository _webHookRepository;

        public WebHookBll()
        {
            _webHookRepository = new WebHookRepository();
        }

        public BaseResponse<DadoBrutoDTO> SaveDadoBruto(DadoBrutoDTO data)
        {
            return _webHookRepository.SaveDadoBruto(data);
        }

        public BaseResponse<RespostaWebHookDTO> SaveRespostaWebHook(RespostaWebHookDTO data)
        {           
            return _webHookRepository.SaveRespostaWebHook(data);
        }
    }
}
