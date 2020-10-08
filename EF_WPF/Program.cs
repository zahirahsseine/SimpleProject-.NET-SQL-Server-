using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_WPF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez saisir le nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le pseudo:");
            string pseudo = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le password:");
            string password = Console.ReadLine();

            using (var db=new efdataEntities())
            {
                
                db.C_user.Add(new C_user { userName = name, pseudoUser =pseudo, passwordUser = password });
                db.SaveChanges();
            }
        
        
        }
    }
}
