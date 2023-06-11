using System;

namespace PassTask13
{
    public class Games
    {
        private string gameID;
        private string gameName;
        /// <summary>
        /// This is a constructer to build a Games object which accepts bookid and bookname.
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="bookname"></param>
        public Games(string bookid, string bookname){
            gameID = bookid;
            gameName = bookname;
        }
        /// <summary>
        /// This is a property to get the information of gameID.
        /// </summary>
        /// <value></value>
        public string GameID{
            get{return gameID;}
        }
        /// <summary>
        /// This is a property to get or set the information of gameName.
        /// </summary>
        /// <value></value>
        public string GameName{
            get{return gameName;}
            set{gameName = value;}
        }
        /// <summary>
        /// This is a method which prints the game information.
        /// </summary>
        public void PrintGameInfo(){
            Console.WriteLine("Game ID: " + gameID);
            Console.WriteLine("Game Name: " + gameName);
        }
    }
}