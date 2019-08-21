using System;
using System.Collections.Generic;
using System.Text;
using take.webhook.core.Contract.Business;
using take.webhook.core.Contract.Repositories;
using take.webhook.core.DTO;
using take.webhook.core.DTO.Entities;
using take.webhook.repository;

namespace take.webhook.business
{
    public class WebHookBll : IWebHookBll
    {
        readonly IDadoBrutoRepository _dadoBrutoRepository;

        public WebHookBll()
        {
            _dadoBrutoRepository = new DadoBrutoRepository();
        }

        public BaseResponse<DadoBrutoDTO> Save(DadoBrutoDTO data)
        {
            return _dadoBrutoRepository.Save(data);
        }
    }
}
