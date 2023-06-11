using System;
using System.Collections.Generic;

namespace PassTask13
{
    public class TransactionList
    {
        private List<Transaction> shopTransaction;
        /// <summary>
        /// This is a constructer of the TransactionList which will create a list of Transaction when initialize.
        /// </summary>
        public TransactionList(){
            shopTransaction = new List<Transaction>();
        }
        /// <summary>
        /// This is a property to get the information of shopTransaction.
        /// </summary>
        /// <value></value>
        public List<Transaction> ShopTransaction{
            get{return shopTransaction;}
        }
        /// <summary>
        /// This is a method to add a transaction into list.
        /// </summary>
        /// <param name="t"></param>
        public void AddShopTrans(Transaction t){
            shopTransaction.Add(t);
        }
        /// <summary>
        /// This is a method to print the transactions made by the shop.
        /// </summary>
        public void PrintShopTrans(){
            Console.WriteLine("============================");
            Console.WriteLine("Transaction List");
            Console.WriteLine("============================");
            foreach(Transaction t in shopTransaction){
                t.PrintTransInfo();
            }
            
        }
    }
    
}