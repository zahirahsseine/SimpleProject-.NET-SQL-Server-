using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Servicewcf" à la fois dans le code, le fichier svc et le fichier de configuration.
public class Servicewcf : IServicewcf
{
    public void DoWork()
    {
    }
    private readonly Repository repo;

   

    public Servicewcf()
    {
        
        efdataEntities db=new efdataEntities();
        this.repo = new Repository(db);
    }
    public bool AddUser(C_user user)
    {
        return repo.addUser(user);
    }

    public bool CheckConnection(string pseudo, string password)
    {

        return repo.checkConnexion(pseudo, password);
    }

   

    public List<C_user> ListUser()
    {
        return repo.listUser();
    }
}
