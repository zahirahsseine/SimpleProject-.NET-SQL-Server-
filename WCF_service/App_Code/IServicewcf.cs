using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServicewcf" à la fois dans le code et le fichier de configuration.
[ServiceContract]
public interface IServicewcf
{
    [OperationContract]
    void DoWork();
  
    [OperationContract]
    bool CheckConnection(string pseudo, string password);
   
    [OperationContract]
    bool AddUser(C_user user);

    [OperationContract]
    List<C_user> ListUser();

}
