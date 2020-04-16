using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWebApiProjet.Repositories
{
    public interface IBiere<TKey,T> : IRepositories<TKey,T> where T:class
    {
        T GetOne(TKey id);
        T GetByName(string name);
    }
}
