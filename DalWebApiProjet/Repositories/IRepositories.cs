using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWebApiProjet.Repositories
{
    public  interface IRepositories<TKey,T> where T: class
    {
        List<T> GetAll();
    }
}
