using System;

namespace PassTask13
{
    public abstract class User
    {
        private string userID;
        private string userPass;
        /// <summary>
        /// This is a constructer to construct an user object which userid and userpass.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="userpass"></param>
        public User(string userid, string userpass){
            userID = userid;
            userPass = userpass;
        }
        /// <summary>
        /// This is a property to get or set the information of userID.
        /// </summary>
        /// <value></value>
        public string UserID{
            get{return userID;}
            set{userID = value;}
        }
        /// <summary>
        /// This is a property to get or set the information of userPass.
        /// </summary>
        /// <value></value>
        public string UserPass{
            get{return userPass;}
            set{userPass = value;}
        }
        /// <summary>
        /// This is a method which checks the user's input with userID and userPass and returns a boolean.
        /// </summary>
        /// <param name="inputID"></param>
        /// <param name="inputPass"></param>
        /// <returns></returns>
        public bool Login(string inputID, string inputPass){
            if(inputID == userID && inputPass == userPass){
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// This is an abstract method which prints the menu and returns a string.
        /// </summary>
        /// <returns></returns>
        public abstract string Menu();
    }
    
}