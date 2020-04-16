using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWebApiProjet.Repositories
{
    public interface IClient<TKey,T> : IRepositories<TKey,T> where T:class
    {
        T GetOne(int id);
        void Create(T parametre);
        void Delete(TKey id);
        void Update(T parametre);
    }
}
