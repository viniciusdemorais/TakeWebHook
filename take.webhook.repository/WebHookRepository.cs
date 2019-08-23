using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using take.webhook.core.Contract.Repositories;
using take.webhook.core.DTO;
using take.webhook.core.DTO.Entities;
using take.webhook.core.Lib;
using take.webhook.entity;
using take.webhook.entity.Entity;

namespace take.webhook.repository
{
    public class WebHookRepository : IWebHookRepository, IDisposable
    {
        private WebHookContext WebHookContext { get; set; }

        public WebHookRepository(WebHookContext context = null)
        {
            if (WebHookContext == null)
                WebHookContext = new WebHookContext();
        }

        public BaseResponse<RespostaWebHookDTO> SaveRespostaWebHook(RespostaWebHookDTO data)
        {
            var resp = new BaseResponse<RespostaWebHookDTO>();
            try
            {
                var objSave = new RespostaWebHook
                {
                    DataCriacao = DateTime.Now,
                    IdRespostaWebHook = data.IdRespostaWebHook,
                    Type = data.Type,
                    Content = data.Content?.ToString(),
                    Id = data.Id,
                    From = data.From,
                    To = data.To,
                    Metadata = data.Metadata?.ToString(),
                    OwnerIdentity = data.OwnerIdentity,
                    Contact = data.Contact?.ToString(),
                    MessageId = data.MessageId,
                    StorageDate = data.StorageDate,
                    Category = data.Category,
                    Action = data.Action,
                    Extras = data.Extras?.ToString()
            };

                int ret;
                bool isModify = WebHookContext.RespostaWebHook.Find(data.IdRespostaWebHook) != null;
                if (!isModify)
                {
                    WebHookContext.Entry(objSave).State = EntityState.Added;
                    ret = WebHookContext.SaveChanges();
                }
                else
                {
                    WebHookContext.Entry(objSave).State = EntityState.Modified;
                    ret = WebHookContext.SaveChanges();
                }

                data = new Mapper<RespostaWebHook, RespostaWebHookDTO>().Convert(objSave);

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

        public BaseResponse<DadoBrutoDTO> SaveDadoBruto(DadoBrutoDTO data)
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
        ~WebHookRepository()
        {
            Dispose();
        }

        public void Dispose()
        {
            WebHookContext.Dispose();
        }
    }
}
