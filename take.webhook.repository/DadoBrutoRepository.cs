using Microsoft.EntityFrameworkCore;
using System;
using take.webhook.core.Contract.Repositories;
using take.webhook.core.DTO;
using take.webhook.core.DTO.Entities;
using take.webhook.core.Lib;
using take.webhook.entity;
using take.webhook.entity.Entity;

namespace take.webhook.repository
{
    public class DadoBrutoRepository : IDadoBrutoRepository, IDisposable
    {
        private WebHookContext WebHookContext { get; set; }

        public DadoBrutoRepository(WebHookContext context = null)
        {
            if (WebHookContext == null)
                WebHookContext = new WebHookContext();
        }

        public BaseResponse<DadoBrutoDTO> Save(DadoBrutoDTO data)
        {
            var resp = new BaseResponse<DadoBrutoDTO>();
            try
            {
                var objSave = new DadoBruto();
                int ret;
                bool isModify = WebHookContext.DadoBruto.Find(data.IdDadoBruto) != null;
                if (!isModify)
                {
                    objSave = new Mapper<DadoBrutoDTO, DadoBruto>().Convert(data);
                    WebHookContext.Entry(objSave).State = EntityState.Added;
                    ret = WebHookContext.SaveChanges();
                }
                else
                {
                    var stored = WebHookContext.DadoBruto.Find(data.IdDadoBruto);
                    objSave = new Mapper<DadoBrutoDTO, DadoBruto>().Convert(data);
                    WebHookContext.Entry(objSave).State = EntityState.Modified;
                    ret = WebHookContext.SaveChanges();
                }

                data = new Mapper<DadoBruto, DadoBrutoDTO>().Convert(objSave);

                if (ret == 0)
                {
                    resp.Object = null;
                    resp.Success = false;
                    resp.Message = "O registro não foi salvo.";
                }
                else
                {
                    resp.Object = data;
                    resp.Message = "O registro foi salvo com sucesso.";
                }
            }
            catch (Exception ex)
            {
                resp.Success = false;
                resp.Message = ex.Message;
            }

            return resp;
        }

        ~DadoBrutoRepository()
        {
            Dispose();
        }

        public void Dispose()
        {
            WebHookContext.Dispose();
        }
    }
}
