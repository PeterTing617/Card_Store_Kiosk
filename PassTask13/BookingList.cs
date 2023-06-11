using System;
using System.Collections.Generic;
using System.Linq;

namespace PassTask13
{
    public class BookingList
    {
        private List<Booking> bookList;
        /// <summary>
        /// This is a constructer of the BookingList which will create a list of Booking when initialize.
        /// </summary>
        public BookingList(){
            bookList = new List<Booking>();
        }
        /// <summary>
        /// This is a property to get or set the information of bookList.
        /// </summary>
        /// <value></value>
        public List<Booking> BookList{
            get{return bookList;}
            set{bookList = value;}
        }
        /// <summary>
        /// This is a property to get the information of the size of bookList.
        /// </summary>
        /// <value></value>
        public int BookTotal{
            get{return bookList.Count;}
        }
        /// <summary>
        /// This is a c# indexer which returns a Booking object from list.
        /// </summary>
        /// <value></value>
        public Booking this[int i]{
            get{return bookList[i];}
        }
        /// <summary>
        /// This is a method which remove a Booking object from list.
        /// </summary>
        /// <param name="b"></param>
        public void RemoveBooking(Booking b){
            bookList.Remove(b);
        }
        /// <summary>
        /// This is a method which add a Booking object into list.
        /// </summary>
        /// <param name="b"></param>
        public void AddBooking(Booking b){
            bookList.Add(b);
        }
        /// <summary>
        /// This is a method which will print all Booking object inside the list.
        /// </summary>
        public void PrintBooking(){
            Console.WriteLine("============================");
            Console.WriteLine("Booking Information");
            Console.WriteLine("============================");
            foreach(Booking b in bookList){
                b.PrintBookingInfo();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// This is a method which will print all ongoing Booking object inside the list.
        /// </summary>
        public void PrintOngoingBooking(){
            Console.WriteLine("============================");
            Console.WriteLine("Ongoing Booking Information");
            Console.WriteLine("============================");
            foreach(Booking b in bookList){
                if(!b.CheckEndTime(DateTime.Now)){
                    b.PrintBookingInfo();
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// This is a method which will clear the Booking history.
        /// </summary>
        public void ClearHistory(){
            if(bookList.Count == 9000){
                foreach(Booking b in bookList){
                    if(b.CheckEndTime(DateTime.Now)){
                        RemoveBooking(b);
                    }
                }
            }
        }
        /// <summary>
        /// This is a method which prints the booking details using BookingNo.
        /// </summary>
        public void SearchBookIDFromList(){
            Console.Write("Enter Booking No: ");
            int bookNo;
            string inputBookNo  = Console.ReadLine().Trim();
            bool validInput = int.TryParse(inputBookNo, out bookNo);
            if(validInput){
                bool searchBooking = false;
                foreach(Booking b in bookList){
                    if(b.BookingNo == bookNo){
                        searchBooking = true;
                        Console.WriteLine("============================");
                        Console.WriteLine("Booking Information");
                        Console.WriteLine("============================");
                        b.PrintBookingInfo();
                        Console.WriteLine();
                    }
                }
                if(!searchBooking){
                    Console.WriteLine("Cannot find booking\n");
                }
            } else {
                Console.WriteLine("Invalid Input\n");
            }
        }
        /// <summary>
        /// This is a method which prints the booking details using custID.
        /// </summary>
        public void SearchBookingUsingCustIDFromList(){
            Console.Write("Enter Customer ID: ");
            string inputCID  = Console.ReadLine().Trim();
            bool search = false;
            foreach(Booking b in bookList){
                if(b.BookCustID == inputCID){
                    search = true;
                    Console.WriteLine("============================");
                    Console.WriteLine("Booking Information");
                    Console.WriteLine("============================");
                    b.PrintBookingInfo();
                    Console.WriteLine();
                }
            }
            if(!search){
                Console.WriteLine("Cannot find booking\n");
            }
        }


    }
    
}