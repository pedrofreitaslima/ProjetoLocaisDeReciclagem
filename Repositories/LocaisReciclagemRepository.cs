using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using ProjetoLocaisDeReciclagem.Data;
using ProjetoLocaisDeReciclagem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoLocaisDeReciclagem.ViewModels.LocaisReciclagemViewModels;

namespace ProjetoLocaisDeReciclagem.Repositories
{
    public class LocaisReciclagemRepository : ILocaisReciclagemRepository
    {
        private readonly DataContext _context;

        public LocaisReciclagemRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListLocaisReciclagemViewModel> Get()
        {
            return _context
                .LocaisReciclagem
                .Select(x => new ListLocaisReciclagemViewModel
                {
                    LocalReciclagemId = x.LocalReciclagemId,
                    Identificacao = x.Identificacao,
                    Logradouro = x.Logradouro, 
                    NumeroEndereco = x.NumeroEndereco,
                    Complemento = x.Complemento,
                    Bairro = x.Bairro,
                    Cidade = x.Cidade,
                    Estado = x.Estado,
                    CEP = x.CEP,
                    Capacidade = x.Capacidade
                })
                .AsNoTracking()
                .ToList();
        }
        public LocaisReciclagem Get(int id)
        {
            return _context.LocaisReciclagem.Find(id);
        }

        public IEnumerable<ListLocaisReciclagemViewModel> GetByIdentificacao(string identificacao)
        {
            return _context
                .LocaisReciclagem
                .Select(x => new ListLocaisReciclagemViewModel
                {
                    LocalReciclagemId = x.LocalReciclagemId,
                    Identificacao = x.Identificacao,
                    Logradouro = x.Logradouro, 
                    NumeroEndereco = x.NumeroEndereco,
                    Complemento = x.Complemento,
                    Bairro = x.Bairro,
                    Cidade = x.Cidade,
                    Estado = x.Estado,
                    CEP = x.CEP,
                    Capacidade = x.Capacidade
                })
                .Where(x => x.Identificacao == identificacao)
                .AsNoTracking()
                .ToList();
        }

        public void Save(LocaisReciclagem locais)
        {
            _context.LocaisReciclagem.Add(locais);
            _context.SaveChanges();
        }
        public void Update(LocaisReciclagem locais)
        {
            _context.Entry<LocaisReciclagem>(locais).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(LocaisReciclagem locais)
        {
            _context.Remove(locais);
            _context.SaveChanges();
        }
    }
}