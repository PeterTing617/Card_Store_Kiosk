using System;
using System.Collections.Generic;

namespace PassTask13
{
    public class CustomerList
    {
        private List<Customer> custList;
        /// <summary>
        /// This is a constructer of the CustomerList which will create a list of Customer when initialize.
        /// </summary>
        public CustomerList(){
            custList = new List<Customer>();
        }
        /// <summary>
        /// This is a property to get the information of the custList.
        /// </summary>
        /// <value></value>
        public List<Customer> CustList{
            get{return custList;}
        }
        /// <summary>
        /// This is a property to get the information of the size of the custList.
        /// </summary>
        /// <value></value>
        public int CustTotal{
            get{return custList.Count;}
        }
        /// <summary>
        /// This is a method which adds a customer object into the list.
        /// </summary>
        /// <param name="cust"></param>
        public void AddCustIntoList(Customer cust){
            custList.Add(cust);
            Console.WriteLine("Added successfully\n");
        }
        /// <summary>
        /// This is a method which removes a customer object from the list.
        /// </summary>
        /// <param name="cust"></param>
        public void DeleteCustFromList(Customer cust){
            custList.Remove(cust);
            Console.WriteLine("Deleted successfully\n");
        }
        /// <summary>
        /// This is a method which edits a customer object from the list.
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="editphone"></param>
        public void EditCustFromList(Customer cust, string editphone){
            cust.CustPhone = editphone;
            Console.WriteLine("Edited successfully\n");
        }
        /// <summary>
        /// This is a method which will search the customer from the list using ID.
        /// </summary>
        public void SearchCustIDFromList(){
            Console.Write("Enter CustomerID: ");
            string searchCustID = Console.ReadLine().Trim(); 
            bool search = false;
            foreach(Customer c in custList){
                c.CheckValid(DateTime.Now);
                if(c.CustID == searchCustID){
                    Console.WriteLine("============================");
                    Console.WriteLine("Customer Info:");
                    Console.WriteLine("============================");
                    c.PrintCustInfo();
                    c.PrintCustTransDetails();
                    Console.WriteLine();
                    search = true;
                }
            }
            if(search == false){
                Console.WriteLine("User Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which will search the customer from the list using name.
        /// </summary>
        public void SearchCustNameFromList(){
            Console.Write("Enter Customer Name: ");
            string searchCustName = Console.ReadLine().Trim(); 
            bool search = false;
            foreach(Customer c in custList){
                c.CheckValid(DateTime.Now);
                if(c.CustID.Contains(searchCustName)){
                    Console.WriteLine("============================");
                    Console.WriteLine("Customer Info:");
                    Console.WriteLine("============================");
                    c.PrintCustInfo();
                    c.PrintCustTransDetails();
                    Console.WriteLine();
                    search = true;
                }
            }
            if(search == false){
                Console.WriteLine("User Not Found\n");
            }
        }
        /// <summary>
        /// This is a method which will return customer name using id.
        /// </summary>
        /// <param name="inputCustID"></param>
        /// <returns></returns>
        public string SearchNameUsingID(string inputCustID){
            bool searched = false;
            foreach(Customer c in custList){
                if(c.CustID == inputCustID){
                    searched = true;
                    return c.CustName;
                }
            }
            if(!searched){
                return "";
            } else {
                return "";
            }
        }
        /// <summary>
        /// This is a method which prints out the loyal customer.
        /// </summary>
        public void DisplayLoyal(){
            Console.WriteLine("============================");
            Console.WriteLine("Loyal Customers:");
            Console.WriteLine("============================");
            foreach(Customer c in custList){
                c.CheckValid(DateTime.Now);
                if(c.TotalPurchases >= 1000){
                    c.PrintCustInfo();
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// This is a method which prints out the customer base.
        /// </summary>
        public void PrintCustBase(){
            Console.WriteLine("============================");
            Console.WriteLine("Customer Base:");
            Console.WriteLine("============================");
            foreach(Customer c in custList){
                c.CheckValid(DateTime.Now);
                c.PrintCustInfo();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// This is a c# indexer which will return a customer from the list.
        /// </summary>
        /// <value></value>
        public Customer this[int i]{
            get{return custList[i];}
        }
    }
}