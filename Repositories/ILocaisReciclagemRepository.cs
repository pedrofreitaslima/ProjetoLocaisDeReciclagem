using System.Collections.Generic;
using ProjetoLocaisDeReciclagem.Models;
using ProjetoLocaisDeReciclagem.ViewModels.LocaisReciclagemViewModels;

namespace ProjetoLocaisDeReciclagem.Repositories
{
    public interface ILocaisReciclagemRepository
    {
        IEnumerable<ListLocaisReciclagemViewModel> Get();
        LocaisReciclagem Get(int id);
        IEnumerable<ListLocaisReciclagemViewModel> GetByIdentificacao(string identificacao);
        void Save(LocaisReciclagem local);
        void Update(LocaisReciclagem local);
    }
}