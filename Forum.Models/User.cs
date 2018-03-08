namespace Forum.Models
{
    using System.Collections.Generic;

    public class User
    {
        private int id;
        private string password;
        private string name;
        private ICollection<int> postIds;

        public ICollection<int> PostIds
        {
            get { return postIds; }
            set { postIds = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}