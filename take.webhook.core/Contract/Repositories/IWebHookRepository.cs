using System;
using System.Collections.Generic;
using System.Text;
using take.webhook.core.DTO;
using take.webhook.core.DTO.Entities;

namespace take.webhook.core.Contract.Repositories
{
    public interface IWebHookRepository
    {
        BaseResponse<RespostaWebHookDTO> SaveRespostaWebHook(RespostaWebHookDTO data);
        BaseResponse<DadoBrutoDTO> SaveDadoBruto(DadoBrutoDTO data);
    }
}
