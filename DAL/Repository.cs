using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository : IRepository<C_user>
    {
        efdataEntities db;
        public Repository(efdataEntities _db)
        {
            this.db = _db;
        }
        public bool addUser(C_user user)
        {
            user.passwordUser= CryptPassword.Hash(user.passwordUser);
            this.db.C_user.Add(user);
            return db.SaveChanges() > 0?true:false;
        }

        public bool checkConnexion(string pseudo, string password)
        {
            string _password = CryptPassword.Hash(password);
            Console.WriteLine(_password);
            return db.C_user.Where(a => a.pseudoUser == pseudo && a.passwordUser ==_password).Count()>0?true:false;
        }

        public List<C_user> listUser()
        {
            return db.C_user.ToList();
        }
    }
}
