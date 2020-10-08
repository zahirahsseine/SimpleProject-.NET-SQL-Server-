using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepository<T>
    {
        bool checkConnexion(string pseudo,string password);
        bool addUser(C_user user);
        List<C_user> listUser();
    }
}
