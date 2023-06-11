using System;
using System.Collections.Generic;

namespace PassTask13
{
    public class Manager:User
    {
        /// <summary>
        /// This is a constructer to build a Manager object which is a child to User and it accepts manID and manPass.
        /// </summary>
        /// <param name="manID"></param>
        /// <param name="manPass"></param>
        /// <returns></returns>
        public Manager(string manID, string manPass):base(manID, manPass){}
        public override string Menu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("(1)Inventory");
            Console.WriteLine("(2)Booking");
            Console.WriteLine("(3)Sales");
            Console.WriteLine("(4)View Transaction");
            Console.WriteLine("(5)View Loyal Customer");
            Console.WriteLine("(6)Log Out");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            Console.WriteLine();
            return option;
        }
        /// <summary>
        /// This is a method where the manager can choose options on viewing the inventory.
        /// </summary>
        /// <param name="il"></param>
        public void Inventory(ItemList il){
            Console.WriteLine("(1)Filter");
            Console.WriteLine("(2)Search item ");
            Console.WriteLine("(3)View inventory");
            Console.WriteLine("(4)Sort inventory");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            Console.WriteLine();
            if(option == "1"){
                il.Filter();
            } else if(option == "2"){
                Console.Write("Search by(1)ID, (2)Name: ");
                string choice = Console.ReadLine().Trim();
                if(choice == "1"){
                    il.SearchItemIDFromList();
                } else if(choice == "2"){
                    il.SearchItemNameFromList();
                } else {
                    Console.WriteLine("Invalid Input\n");
                }
            } else if(option == "3"){
                il.PrintInventory();
            } else if(option == "4"){
                SortInventory(il);
            } else {
                Console.WriteLine("Invalid input\n");
            }
        }
        /// <summary>
        /// This is a method where the manager can choose options on viewing the booking list.
        /// </summary>
        /// <param name="bl"></param>
        public void Booking(BookingList bl){
            Console.WriteLine("(1)View Booking");
            Console.WriteLine("(2)View Ongoing Booking");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            Console.WriteLine();
            if(option == "1"){
                bl.PrintBooking();
            } else if(option == "2"){
                bl.PrintOngoingBooking();
            } else {
                Console.WriteLine("Invalid input\n");
            }
        }
        /// <summary>
        /// This is a method where the manager can choose options on viewing the sales.
        /// </summary>
        /// <param name="bl"></param>
        public void Sales(TransactionList tl){
            Console.WriteLine("(1)Daily Sales");
            Console.WriteLine("(2)Monthly Sales");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            Console.WriteLine();
            if(option == "1"){
                DailySales(tl);
            } else if(option == "2"){
                MonthlySales(tl);
            } else {
                Console.WriteLine("Invalid input\n");
            }
        }
        /// <summary>
        /// This is a method where the manager can see all loyal customer.
        /// </summary>
        /// <param name="cl"></param>
        public void ViewLoyal(CustomerList cl){
            cl.DisplayLoyal();
        }
        public void ViewTransaction(TransactionList tl){
            tl.PrintShopTrans();
        }
        /// <summary>
        /// This is a method where the manager can choose options on sorting the inventory.
        /// </summary>
        /// <param name="il"></param>
        public void SortInventory(ItemList il){
            Console.Write("Sorted By(1)Series No, (2)Name, (3)Color, (4)Rarity, (5)Foil, (6)Price, (7)Quantity, (8)Promotion: ");
            string sortOption = Console.ReadLine().Trim(); 
            if(sortOption == "1"){
                il.PrintSortInventory("SeriesNo");
            } else if(sortOption == "2"){
                il.PrintSortInventory("Name");
            } else if(sortOption == "3"){
                il.PrintSortInventory("Color");
            } else if(sortOption == "4"){
                il.PrintSortInventory("Rarity");
            } else if(sortOption == "5"){
                il.PrintSortInventory("Foil");
            } else if(sortOption == "6"){
                il.PrintSortInventory("Price");
            } else if(sortOption == "7"){
                il.PrintSortInventory("Quantity");
            } else if(sortOption == "8"){
                il.PrintSortInventory("Promotion");
            } else {
                Console.WriteLine("Invalid input\n");
            }
        }
        /// <summary>
        /// This is a method where the manager can see the sales of each item daily.
        /// </summary>
        /// <param name="tl"></param>
        public void DailySales(TransactionList tl){
            List<DateTime> dtList = new List<DateTime>();
            foreach(Transaction t in tl.ShopTransaction){
                if(!dtList.Contains(t.TransDate.Date)){
                    dtList.Add(t.TransDate.Date);
                }
            }
            foreach(DateTime d in dtList){
                Sales ds = new Sales(d);
                foreach(Transaction t in tl.ShopTransaction){
                    if(t.TransDate.Date == ds._Date){
                        ds._Earned += t.TotalSpent;
                        foreach(Item i in t.BuyList){
                            ItemCount newItem = new ItemCount(i);
                            ds.AddIC(newItem);
                        }
                    }
                }
                Console.WriteLine("============================");
                Console.WriteLine("Daily Sales");
                Console.WriteLine("============================");
                Console.WriteLine("Date: " + ds._Date);
                foreach(ItemCount ic in ds._ItemC){
                    ic._Item.PrintCardInfoSales();
                    Console.WriteLine("Sold: " + ic._Count + "\n");
                }
                Console.WriteLine("Earned(RM): " + ds._Earned + "\n");
            }
        }
        /// <summary>
        /// This is a method where the manager can see the sales of each item monthly.
        /// </summary>
        /// <param name="tl"></param>
        public void MonthlySales(TransactionList tl){
            List<DateTime> dtList = new List<DateTime>();
            foreach(Transaction t in tl.ShopTransaction){
                DateTime dt = new DateTime(t.TransDate.Year,t.TransDate.Month,1);
                if(!dtList.Contains(dt)){
                    dtList.Add(dt);
                }
            }
            foreach(DateTime d in dtList){
                Sales ds = new Sales(d);
                foreach(Transaction t in tl.ShopTransaction){
                    DateTime transDT = new DateTime(t.TransDate.Year,t.TransDate.Month,1);
                    if(transDT == ds._Date){
                        ds._Earned += t.TotalSpent;
                        foreach(Item i in t.BuyList){
                            ItemCount newItem = new ItemCount(i);
                            ds.AddIC(newItem);
                        }
                    }
                }
                Console.WriteLine("============================");
                Console.WriteLine("Monthly Sales");
                Console.WriteLine("============================");
                Console.WriteLine("Date: " + ds._Date);
                foreach(ItemCount ic in ds._ItemC){
                    ic._Item.PrintCardInfoSales();
                    Console.WriteLine("Sold: " + ic._Count + "\n");
                }
                Console.WriteLine("Earned(RM): " + ds._Earned + "\n");
            }
        }

    }
}