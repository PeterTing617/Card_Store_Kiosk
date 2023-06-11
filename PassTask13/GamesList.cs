using System;
using System.Collections.Generic;
using System.Linq;

namespace PassTask13
{
    public class GamesList
    {
        private List<Games> gameList;
        /// <summary>
        /// This is a constructer of the GamesList which will create a list of Games when initialize.
        /// </summary>
        public GamesList(){
            gameList = new List<Games>();
        }
        /// <summary>
        /// This is a property to get the information of gameList.
        /// </summary>
        /// <value></value>
        public List<Games> GameList{
            get{return gameList;}
        }
        /// <summary>
        /// This is a property to get the information of the size of gameList.
        /// </summary>
        /// <value></value>
        public int GameTotal{
            get{return gameList.Count;}
        }
        /// <summary>
        /// This is a method to add a Games object into the list.
        /// </summary>
        /// <param name="g"></param>
        public void AddGamesIntoList(Games g){
            gameList.Add(g);
            Console.WriteLine("Added successfully\n");
        }
        /// <summary>
        /// This is a method to remove a Games object from the list.
        /// </summary>
        /// <param name="g"></param>
        public void RemoveGamesFromList(Games g){
            gameList.Remove(g);
            Console.WriteLine("Removed successfully\n");
        }
        /// <summary>
        /// This is a method to search a Games object from the list using gameID.
        /// </summary>
        /// <param name="bl"></param>
        public void SearchGameIDFromList(BookingList bl){
            Console.Write("Enter Game ID: ");
            string searchGameID = Console.ReadLine().Trim(); 
            bool search = false;
            foreach(Games g in gameList){
                if(g.GameID == searchGameID){
                    Console.WriteLine("============================");
                    Console.WriteLine("Game Info:");
                    Console.WriteLine("============================");
                    g.PrintGameInfo();
                    Console.WriteLine("============================");
                    Console.WriteLine("Ongoing Booking Details:");
                    Console.WriteLine("============================");
                    foreach(Booking b in bl.BookList){
                        if(b.bookGame.GameID == searchGameID){
                            if(!b.CheckEndTime(DateTime.Now)){
                                b.PrintBookingInfo();
                                Console.WriteLine();
                            }
                        }
                    }
                    search = true;
                }
            }
            if(search == false){
                Console.WriteLine("Game Not Found\n");
            }
        }
        /// <summary>
        /// This is a method to search a Games object from the list using gameName.
        /// </summary>
        public void SearchGameNameFromList(){
            Console.Write("Enter Game Name: ");
            string searchGameName = Console.ReadLine().Trim(); 
            bool search = false;
            foreach(Games g in gameList){
                if(g.GameName.Contains(searchGameName)){
                    Console.WriteLine("============================");
                    Console.WriteLine("Game Info:");
                    Console.WriteLine("============================");
                    g.PrintGameInfo();
                    Console.WriteLine();
                    search = true;
                }
            }
            if(search == false){
                Console.WriteLine("Game Not Found\n");
            }
        }
        /// <summary>
        /// This is a method to print the gameList.
        /// </summary>
        public void PrintGamesList(){
            Console.WriteLine("============================");
            Console.WriteLine("Games List:");
            Console.WriteLine("============================");
            foreach(Games g in gameList){
                g.PrintGameInfo();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// This is a method to print the sorted gameList.
        /// </summary>
        /// <param name="sortBy"></param>
        public void PrintSortGameList(string sortBy){
            Console.WriteLine("============================");
            Console.WriteLine("Sorted Games List:");
            Console.WriteLine("============================");
            if(sortBy == "GameID"){
                List<Games> sortList = gameList.OrderBy(game => game.GameID).ToList();
                foreach(Games g in sortList){
                    g.PrintGameInfo();
                    Console.WriteLine();
                }
            } else if(sortBy == "GameName"){
                List<Games> sortList = gameList.OrderBy(game => game.GameName).ToList();
                foreach(Games g in sortList){
                    g.PrintGameInfo();
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// This is a c# indexer which returns a Games object from the list.
        /// </summary>
        /// <value></value>
        public Games this[int i]{
            get{return gameList[i];}
        }
    }
}