using System;
using NUnit.Framework;

namespace PassTask13{
    [TestFixture]
    public class BookingTest{
        [Test]
        public void TestCheckClash(){
            DateTime bookTime = new DateTime(2021,12,24,14,0,0);
            DateTime startTime = new DateTime(2021,12,24,14,0,0);
            DateTime endTime = new DateTime(2021,12,24,16,0,0);
            Games newGame = new Games("1001","Monopoly");
            Booking newBook = new Booking(1001,newGame,"1001","Peter",bookTime,2);
            newBook.CalculateEndTime();
            Assert.AreEqual(true, newBook.CheckClash(startTime,endTime));

            startTime = new DateTime(2021,12,24,13,0,0);
            endTime = new DateTime(2021,12,24,15,0,0);
            Assert.AreEqual(true, newBook.CheckClash(startTime,endTime));

            startTime = new DateTime(2021,12,24,15,0,0);
            endTime = new DateTime(2021,12,24,17,0,0);
            Assert.AreEqual(true, newBook.CheckClash(startTime,endTime));

            startTime = new DateTime(2021,12,24,9,0,0);
            endTime = new DateTime(2021,12,24,10,0,0);
            Assert.AreEqual(false, newBook.CheckClash(startTime,endTime));
        }
        [Test]
        public void TestCancelBooking(){
            DateTime bookTime = new DateTime(2021,12,24,14,0,0);
            DateTime currentTime = new DateTime(2021,12,23,14,0,0);
            Games newGame = new Games("1001","Monopoly");
            Booking newBook = new Booking(1001,newGame,"1001","Peter",bookTime,2);
            newBook.CalculateEndTime();
            Assert.AreEqual(true, newBook.CheckCancelBook(currentTime));

            currentTime = new DateTime(2021,12,23,14,0,1);
            Assert.AreEqual(false, newBook.CheckCancelBook(currentTime));
        }
        [Test]
        public void TestCheckEnd(){
            DateTime bookTime = new DateTime(2021,12,24,14,0,0);
            DateTime currentTime = new DateTime(2021,12,24,15,0,0);
            Games newGame = new Games("1001","Monopoly");
            Booking newBook = new Booking(1001,newGame,"1001","Peter",bookTime,2);
            newBook.CalculateEndTime();
            Assert.AreEqual(false, newBook.CheckEndTime(currentTime));

            currentTime = new DateTime(2021,12,24,16,0,0);
            Assert.AreEqual(true, newBook.CheckEndTime(currentTime));
        }
    }
}