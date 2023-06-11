using System;

namespace PassTask13
{
    public class Booking
    {
        public int bookingNo;
        public Games bookGame;
        private string bookCustID;
        private string bookCustName;
        private DateTime startTime;
        private DateTime endTime;
        private int bookDuration;
        /// <summary>
        /// This is a constructer to construct a Booking object which accept bookNo, games, custID, custN, start and drtion.
        /// </summary>
        /// <param name="bookNo"></param>
        /// <param name="games"></param>
        /// <param name="custID"></param>
        /// <param name="custN"></param>
        /// <param name="start"></param>
        /// <param name="drtion"></param>
        public Booking(int bookNo, Games games, string custID, string custN, DateTime start, int drtion){
            bookingNo = bookNo;
            bookGame = games;
            bookCustID = custID;
            bookCustName = custN;
            startTime = start;
            bookDuration = drtion;
            CalculateEndTime();
        }
        /// <summary>
        /// This is a property to get the information of bookingNo.
        /// </summary>
        /// <value></value>
        public int BookingNo{
            get{return bookingNo;}
        }
        /// <summary>
        /// This is a property to get or set the information of bookGame.
        /// </summary>
        /// <value></value>
        public Games BookGame{
            get{return bookGame;}
            set{bookGame = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of bookCustID.
        /// </summary>
        /// <value></value>
        public string BookCustID{
            get{return bookCustID;}
            set{bookCustID = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of bookCustName.
        /// </summary>
        /// <value></value>
        public string BookCustName{
            get{return bookCustName;}
            set{bookCustName = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of startTime.
        /// </summary>
        /// <value></value>
        public DateTime StartTime{
            get{return startTime;}
            set{startTime = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of endTime.
        /// </summary>
        /// <value></value>
        public DateTime EndTime{
            get{return endTime;}
            set{endTime = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of bookDuration.
        /// </summary>
        /// <value></value>
        public int BookDuration{
            get{return bookDuration;}
            set{bookDuration = value;}
        }
        /// <summary>
        /// This is a method to calculate endTime based on startTime and bookDuration.
        /// </summary>
        public void CalculateEndTime(){
            endTime = startTime.AddHours(bookDuration);
        }
        /// <summary>
        /// This is a method to check whether the booking has reached the end and returns a boolean.
        /// </summary>
        /// <returns></returns>
        public bool CheckEndTime(DateTime dt){
            if(dt >= endTime){
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// This is a method to check whether the booking can be cancelled and returns a boolean.
        /// </summary>
        /// <returns></returns>
        public bool CheckCancelBook(DateTime dt){
            int testDate = DateTime.Compare(dt.AddHours(24),startTime);
            if(testDate <= 0){
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// This is a method to check whether the time inputed clashed with the booking object and returns a boolean.
        /// </summary>
        /// <param name="dStart"></param>
        /// <param name="dEnd"></param>
        /// <returns></returns>
        public bool CheckClash(DateTime dStart, DateTime dEnd){
            if((dStart>=startTime) && (dStart<endTime) || (dEnd>=startTime) && (dEnd<endTime)){
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// This is a method to print the booking information.
        /// </summary>
        public void PrintBookingInfo(){
            Console.WriteLine("Booking Number: " + bookingNo);
            Console.WriteLine("Game ID: " + bookGame.GameID);
            Console.WriteLine("Game Name: " + bookGame.GameName);
            Console.WriteLine("Booked Customer ID: " + bookCustID);
            Console.WriteLine("Booked Customer Name: " + bookCustName);
            Console.WriteLine("Start Time: " + startTime);
            Console.WriteLine("End Time: " + endTime);
            Console.WriteLine("Booked Duration(hours): " + bookDuration);
        }
    }
}