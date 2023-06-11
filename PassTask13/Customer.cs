using System;
using System.Collections.Generic;

namespace PassTask13
{
    public class Customer
    {
        private string custID;
        private string custName;
        private string custPhone;
        private bool validMembership;
        private DateTime dateEnd;
        private double totalPurchases;
        private int totalPoints;
        private List<Transaction> custTransactionList;
        /// <summary>
        /// This is a constructer to construct a customer object which accept id, name and phone.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        public Customer(string id, string name, string phone){
            custID = id;
            custName = name;
            custPhone = phone;
            totalPurchases = 0;
            totalPoints = 0;
            custTransactionList = new List<Transaction>();
        }
        /// <summary>
        /// This is a property to get the value of custID.
        /// </summary>
        /// <value></value>
        public string CustID{
            get{return custID;}
        }
        /// <summary>
        /// This is a property to get the value of custName.
        /// </summary>
        /// <value></value>
        public string CustName{
            get{return custName;}
        }
        /// <summary>
        /// This is a property to get the value or set the value of custPhone.
        /// </summary>
        /// <value></value>
        public string CustPhone{
            get{return custPhone;}
            set{custPhone = value;}
        }
        /// <summary>
        /// This is a property to get the value or set the value of validMembership.
        /// </summary>
        /// <value></value>
        public bool ValidMembership{
            get{return validMembership;}
            set{validMembership = value;}
        }
        /// <summary>
        /// This is a property to get the value or set the value of dateEnd.
        /// </summary>
        /// <value></value>
        public DateTime DateEnd{
            get{return dateEnd;}
            set{dateEnd = value;}
        }
        /// <summary>
        /// This is a property to get the value of totalPurchases.
        /// </summary>
        /// <value></value>
        public double TotalPurchases{
            get{return totalPurchases;}
        }
        /// <summary>
        /// This is a property to get the value of totalPoints.
        /// </summary>
        /// <value></value>
        public int TotalPoints{
            get{return totalPoints;}
        }
        /// <summary>
        /// This is a property to get the value of custTransactionList.
        /// </summary>
        /// <value></value>
        public List<Transaction> CustTransactionList{
            get{return custTransactionList;}
        }
        /// <summary>
        /// This is a method to update the customer membership by one year.
        /// </summary>
        public void UpdateCustMembership(){
            validMembership = true;
            dateEnd = DateTime.Now.AddYears(1);
        }
        /// <summary>
        /// This is a method to check whether the membership has reached the end.
        /// </summary>
        public void CheckValid(DateTime dt){
            if(dt > dateEnd){
                validMembership = false;
            } else {
                validMembership = true;
            }
        }
        /// <summary>
        /// This is a method to update the total spent by the customer.
        /// </summary>
        public void UpdateTotalPurchases(){
            double tp = 0;
            foreach(Transaction t in custTransactionList){
                tp += t.TotalSpent;
            }
            totalPurchases = tp;
        }
        /// <summary>
        /// This is a method to update the total points obtained by the customer.
        /// </summary>
        public void UpdatePoints(){
            totalPoints = Convert.ToInt32((totalPurchases / 20) * 10);
        }
        /// <summary>
        /// This is a method to record the transaction into the custTransactionList.
        /// </summary>
        /// <param name="t"></param>
        public void AddTransCust(Transaction t){
            custTransactionList.Add(t);
        }
        /// <summary>
        /// This is a method to print the customer information.
        /// </summary>
        public void PrintCustInfo(){
            Console.WriteLine("Customer ID: " + custID);
            Console.WriteLine("Customer Name: " + custName);
            Console.WriteLine("Customer Phone Number: " + custPhone);
            Console.WriteLine("Customer Membership: " + validMembership);
            Console.WriteLine("Membership valid till: " + dateEnd);
            Console.WriteLine("Total Purchases(RM): " + totalPurchases);
            Console.WriteLine("Total Points: " + totalPoints);
        }
        /// <summary>
        /// This is a method to print the transaction made by the customer.
        /// </summary>
        public void PrintCustTransDetails(){
            Console.WriteLine("Transactions made:");
            Console.WriteLine("============================");
            foreach(Transaction t in custTransactionList){
                t.PrintTransInfo();
                Console.WriteLine();
            }
        }
    }
}