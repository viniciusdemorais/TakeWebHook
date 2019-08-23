using take.webhook.core.DTO;
using take.webhook.core.DTO.Entities;

namespace take.webhook.core.Contract.Business
{
    public interface IWebHookBll
    {
        BaseResponse<DadoBrutoDTO> SaveDadoBruto(DadoBrutoDTO data);
        BaseResponse<RespostaWebHookDTO> SaveRespostaWebHook(RespostaWebHookDTO data);
    }
}
