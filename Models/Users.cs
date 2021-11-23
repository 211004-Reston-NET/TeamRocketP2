
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Models
{
    public class User
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _UserPass;
        public string UserPass
        {
            get { return _UserPass; }
            set { _UserPass = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public  List<Forum> Forums { get; set; }
        public List<Invite> Invites { get; set; }
        public List<Post> Posts { get; set; }
        public List<Reply> Replies { get; set; }


        public override string ToString()
        {
            return $"ID: {ID}\nName: {UserName}\nEmail: {Email}";
        }

    }
}