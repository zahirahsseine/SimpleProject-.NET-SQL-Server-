
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        ServiceReference1.ServicewcfClient client = new ServiceReference1.ServicewcfClient();
        ServiceReference1.C_user usr = new ServiceReference1.C_user();
        public static IDictionary<string, bool> session =new Dictionary<string, bool>() ;
       public string AskUserAboutValue(string msg)
        {
            

            string val = "";
            do
            {
                Console.WriteLine(msg);
                val = Console.ReadLine();
            }
            while (val.Length == 0);
          
            return val;
        }
        public void AddUser()
        {
            usr.userName = AskUserAboutValue("Veuillez saisir le nom:");
            usr.pseudoUser = AskUserAboutValue("Veuillez saisir le pseudo:");
            usr.passwordUser = AskUserAboutValue("Veuillez saisir le password:");

            bool checkOperationDoing = client.AddUser(usr);

            Console.WriteLine(checkOperationDoing ? "Succesfull Operation" : "Failed Operation");
            ChooseOperation();
        }
         public void ListUser()
        {
           var   list=  client.ListUser();
            Console.WriteLine("***********************************************************");
            Console.WriteLine("ID      || Name                  ||Pseudo                  ||");
            foreach (var item in list)
            {
             
                Console.WriteLine(item.idUser +"    ||  "+item.userName+"    ||  "+item.pseudoUser+"||");
               
               
            }
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Number Of lignes"+list.Count());
            string operation = Console.ReadLine();
            runOperation(operation);
        }
       
        public void runOperation(string operation)
        {

            try
            {
                bool checksession = !session.ContainsKey("IsConnected") || !session["IsConnected"];
                int op = Convert.ToInt32(operation);
                while (op < 0 && op > 3)
                {
                    Console.WriteLine("Please try choose a valid operation");
                    op = Convert.ToInt32(Console.ReadLine());
                }
                switch (Convert.ToInt32(op))
                {
                    case 0: { SignIn(); break; }
                    case 1: { if (!checksession) ListUser(); else SignIn(); break; }
                    case 2: { if (!checksession)  AddUser(); else SignIn(); break; }
                    case 3: { SignOut(); break; }
                    case 4: { ChooseOperation(); break; }
                    default: { ConfirmExit(); break; }
                }
            }
            catch(Exception Ex)
            {
                Console.WriteLine("Invalid Operation");
                ConfirmExit();

            }
           
        }
        public void ConfirmExit()
        {
            Console.WriteLine("Are you sure you want to skip? Y/N");
            string confirmExit = Console.ReadLine();
            if (confirmExit.ToUpper() == "Y")
                Console.WriteLine("Good by");
            else
                ChooseOperation();
        }
        public void ChooseOperation()
        {
         
                if (!session.ContainsKey("IsConnected") || !session["IsConnected"])
                {
                    Console.WriteLine("For access to feature of apps, you should sign in, please choose:");
                    Console.WriteLine("0-To Sign In.");
                    Console.WriteLine("5-To Exit.");
                }
                else
                {
                    Console.WriteLine("Please! Choose the operation to do:");
                    Console.WriteLine("1-Listing users.");
                    Console.WriteLine("2-Add new user.");
                    Console.WriteLine("3-Sign Out.");
                    Console.WriteLine("4-Go to main list.");
                    Console.WriteLine("5-Exit.");
               
                }
            string operation = Console.ReadLine();
           
            runOperation(operation);
        }
        public void SignOut()
        {
            session["IsConnected"]=false;
            ChooseOperation();
        }
        public void SignIn()
        {
            Console.WriteLine("Veuillez saisir le pseudo:");
            string pseudoUser = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le password:");
            Console.ForegroundColor = ConsoleColor.Black;
            string passwordUser = Console.ReadLine();

            bool CheckInfoUser = client.CheckConnection(pseudoUser, passwordUser);
            Console.ForegroundColor = ConsoleColor.White;
            if (CheckInfoUser)
            {
                session.Add("IsConnected", true);
                ChooseOperation();
            }
            else
            {
                Console.WriteLine("Your login or password are incorrect, try again by choosen '0' or return to main list by choosen '4'");
               string op=Console.ReadLine();
                runOperation(op);
            }
            
            
        }
        static void Main(string[] args)
        {

           new Program().ChooseOperation();


        }
    }
}
