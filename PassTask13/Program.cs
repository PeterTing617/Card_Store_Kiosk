// Peter Ting Tiew Hieng
// 101226836
using System;

namespace PassTask13
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("man1001", "1234");
            Admin admin = new Admin("ad1001", "1234");

            ItemList il = new ItemList();
            CustomerList cl = new CustomerList();
            TransactionList tl = new TransactionList();
            BookingList bl = new BookingList();
            GamesList gl = new GamesList();
            bool quit = false;
            bool logged = false;

            while(quit == false){
                Console.WriteLine("Manager: ID - man1001, Pass - 1234");
                Console.WriteLine("Admin: ID - ad1001, Pass - 1234");
                Console.WriteLine("Enter quit at userID to terminate program.");
                Console.Write("Enter user ID: ");
                string userinputID = Console.ReadLine().Trim();
                Console.Write("Enter user Password: ");
                string userinputPass = Console.ReadLine().Trim();

                if(manager.Login(userinputID,userinputPass)){
                    Console.WriteLine("\nWelcome Manager");
                    logged = true;
                    string option;
                    while(logged){
                        option = manager.Menu();
                        if(option == "1"){
                            manager.Inventory(il);
                        } else if(option == "2"){
                            manager.Booking(bl);
                        } else if(option == "3"){
                            manager.Sales(tl);
                        } else if(option == "4"){
                            tl.PrintShopTrans();
                        } else if(option == "5"){
                            manager.ViewLoyal(cl);
                        } else if(option == "6"){
                            Console.WriteLine("Logged out\n");
                            break;
                        } else {
                            Console.WriteLine("Invalid input\n");
                        }
                    }
                } else if(admin.Login(userinputID,userinputPass)){
                    Console.WriteLine("\nWelcome Shop Admin");
                    logged = true;
                    string option;
                    while(logged){
                        option = admin.Menu();
                        if(option == "1"){
                            admin.ManageCustomer(cl, bl);
                        } else if(option == "2"){
                            admin.ManageInventory(il);
                        } else if(option == "3"){
                            admin.ManageBooking(bl, gl, cl);
                        } else if(option == "4"){
                            admin.ManageTransaction(cl,il,tl);
                        } else if(option == "5"){
                            tl.PrintShopTrans();
                        } else if(option == "6"){
                            Console.WriteLine("Logged out\n");
                            break;
                        }
                    }
                } else if(userinputID == "quit"){
                    Console.WriteLine("Program terminate");
                    quit = true;
                } else {
                    Console.WriteLine("Invalid input\n");
                }
            }
        }
    }
}

