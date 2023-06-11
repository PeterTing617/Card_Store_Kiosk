using System;
using System.Collections.Generic;

namespace PassTask13
{
    public class Transaction
    {
        private DateTime transDate;
        private double totalSpent;
        private List<Item> buyList;
        private bool customerMember;
        private double totalDiscount;
        private string custIDBought;
        private string custNameBought;
        /// <summary>
        /// This is a constructer to construct a transaction object which accept custM which identifies whether the transaction is done by a member or not.
        /// </summary>
        /// <param name="custM"></param>
        public Transaction(bool custM){
            customerMember = custM;
            buyList = new List<Item>();
        }
        /// <summary>
        /// This is a property to get or set the information of transDate.
        /// </summary>
        /// <value></value>
        public DateTime TransDate{
            get{return transDate;}
            set{transDate = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of totalSpent.
        /// </summary>
        /// <value></value>
        public double TotalSpent{
            get{return totalSpent;}
            set{totalSpent = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of buyList.
        /// </summary>
        /// <value></value>
        public List<Item> BuyList{
            get{return buyList;}
        }
        /// <summary>
        /// This is a property to get or set the information of customerMember.
        /// </summary>
        /// <value></value>
        public bool CustomerMember{
            get{return customerMember;}
            set{customerMember = value;}
        }
        /// <summary>
        /// This is a property to get the information of the size of buyList.
        /// </summary>
        /// <value></value>
        public int ItemTransTotal{
            get{return buyList.Count;}
        }
        /// <summary>
        /// This is a property to get or set the information of totalDiscount.
        /// </summary>
        /// <value></value>
        public double TotalDiscount{
            get{return totalDiscount;}
            set{totalDiscount = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of custIDBought.
        /// </summary>
        /// <value></value>
        public string CustIDBought{
            get{return custIDBought;}
            set{custIDBought = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of custNameBought.
        /// </summary>
        /// <value></value>
        public string CustNameBought{
            get{return custNameBought;}
            set{custNameBought = value;}
        }
        /// <summary>
        /// This is a method which adds an item into the buyList.
        /// </summary>
        /// <param name="i"></param>
        public void AddBuy(Item i){
            buyList.Add(i);
        }
        /// <summary>
        /// This is a method which removes an item from the buyList.
        /// </summary>
        /// <param name="i"></param>
        public void RemoveBuy(Item i){
            buyList.Remove(i);
        }
        /// <summary>
        /// This is a method which updates the total spent.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="valid"></param>
        public void UpdateSpent(bool valid){
            double custSpent = 0;
            double custDiscount = 0;
            foreach(Item i in buyList){
                if(customerMember){
                    if(valid){
                        if(!i.PromotionItem){
                            custSpent += i.CardPrice * 0.8;
                            custDiscount += i.CardPrice - i.CardPrice * 0.8;
                        } else {
                            custSpent += i.CardPrice;
                        }
                    } else {
                        custSpent += i.CardPrice;
                    }
                } else {
                    custSpent += i.CardPrice;
                }
            }
            totalSpent = custSpent;
            totalDiscount = custDiscount; 
        }
        /// <summary>
        /// This is a method which prints the transaction information.
        /// </summary>
        public void PrintTransInfo(){
            Console.WriteLine("Date of transaction: " + transDate);
            Console.WriteLine("Total spent: " + totalSpent);
            Console.WriteLine("Total Discount: " + totalDiscount);
            Console.WriteLine("Member: " + customerMember);
            if(customerMember){
                Console.WriteLine("Customer ID: " + custIDBought);
                Console.WriteLine("Customer Name: " + custNameBought);
            }
            Console.WriteLine("No of items bought: " + ItemTransTotal);
            Console.WriteLine("Items bought: ");
            foreach(Item i in buyList){
                Console.WriteLine("Series No: " + i.SeriesNo);
                Console.WriteLine("Card Name: " + i.CardName);
                Console.WriteLine("Card Rarity: " + i.CardRarity);
                Console.WriteLine("Card Color: " + i.CardColor);
                Console.WriteLine("Foil: " + i.CardFoil);
                Console.WriteLine("Price: " + i.CardPrice);
                Console.WriteLine();
            }
        }
        /// <summary>
        /// This is a c# indexer which returns an item object from list.
        /// </summary>
        /// <value></value>
        public Item this[int i]{
            get{return buyList[i];}
        }

    }
    
}