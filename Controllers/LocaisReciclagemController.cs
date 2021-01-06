using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjetoLocaisDeReciclagem.Models;
using ProjetoLocaisDeReciclagem.Data;
using ProjetoLocaisDeReciclagem.Repositories;
using ProjetoLocaisDeReciclagem.ViewModels.LocaisReciclagemViewModels;
using System.Threading.Tasks;

namespace ProjetoLocaisDeReciclagem.Controllers
{
    [ApiController]
    [Route("v1/locais")]
    public class LocaisReciclagemController : Controller
    {
        private readonly LocaisReciclagemRepository _repository;

        public LocaisReciclagemController(LocaisReciclagemRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<ListLocaisReciclagemViewModel> Get()
        {
            return _repository.Get();
            
        }

        [Route("{id:int}")]
        [HttpGet]
        public LocaisReciclagem Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("{identificacao}")]
        [HttpGet]
        public IEnumerable<ListLocaisReciclagemViewModel> GetByIdentificacao(string identificacao)
        {
            var ident = identificacao.Trim();
            return _repository.GetByIdentificacao(ident);
        }

        [Route("")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorLocaisReciclagemViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o local",
                    Data = model.Notifications
                };

            try
            {
                var locais = new LocaisReciclagem();
                locais.Identificacao = model.Identificacao;
                locais.CEP = model.CEP;
                locais.DataRegistro = DateTime.Now;
                locais.Logradouro = model.Logradouro;
                locais.NumeroEndereco = model.NumeroEndereco;
                locais.DataUltimaAlteracao = DateTime.Now; 
                locais.Complemento = model.Complemento;
                locais.Bairro = model.Bairro;
                locais.Cidade = model.Cidade;
                locais.Estado = model.Estado;
                locais.Capacidade = model.Capacidade;

                _repository.Save(locais);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Local cadastrado com sucesso!",
                    Data = locais
                };
            }
            catch(Exception)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o local",
                    Data = model.Notifications
                };
            }
        }


        [Route("")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorLocaisReciclagemViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o local",
                    Data = model.Notifications
                };

            try
            {
                var locais = new LocaisReciclagem();
                locais.LocalReciclagemId = model.LocalReciclagemId;
                locais.Identificacao = model.Identificacao;
                locais.CEP = model.CEP;
                locais.DataRegistro = DateTime.Now;
                locais.Logradouro = model.Logradouro;
                locais.NumeroEndereco = model.NumeroEndereco;
                locais.DataUltimaAlteracao = DateTime.Now; 
                locais.Complemento = model.Complemento;
                locais.Bairro = model.Bairro;
                locais.Cidade = model.Cidade;
                locais.Estado = model.Estado;
                locais.Capacidade = model.Capacidade;

                _repository.Update(locais);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Local alterado com sucesso!",
                    Data = locais
                };
            }
            catch(Exception)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o local",
                    Data = model.Notifications
                };
            }
        }

        [HttpDelete]
        [Route("")]
        public ResultViewModel Delete([FromBody]EditorLocaisReciclagemViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o local",
                    Data = model.Notifications
                };

            try
            {
                var locais = new LocaisReciclagem();
                locais.LocalReciclagemId = model.LocalReciclagemId;
                locais.Identificacao = model.Identificacao;
                locais.CEP = model.CEP;
                locais.DataRegistro = DateTime.Now;
                locais.Logradouro = model.Logradouro;
                locais.NumeroEndereco = model.NumeroEndereco;
                locais.DataUltimaAlteracao = DateTime.Now; 
                locais.Complemento = model.Complemento;
                locais.Bairro = model.Bairro;
                locais.Cidade = model.Cidade;
                locais.Estado = model.Estado;
                locais.Capacidade = model.Capacidade;

                _repository.Delete(locais);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Local apagado com sucesso!",
                    Data = model
                };
            }
            catch (Exception)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível remover o local",
                    Data = model.Notifications
                };
            }
        }
        
    }
}