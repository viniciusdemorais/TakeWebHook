using take.webhook.core.DTO;
using take.webhook.core.DTO.Entities;

namespace take.webhook.core.Contract.Repositories
{
    public interface IDadoBrutoRepository
    {
        BaseResponse<DadoBrutoDTO> Save(DadoBrutoDTO data);
    }
}
