namespace Forum.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class User
    {
        private int id;
        private string password;
        private string name;
        private ICollection<int> postIds;

        public User(int id, string name, string password, IEnumerable<int> postIds)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.PostIds = postIds.ToList();
        }

        public User(int id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.PostIds = new List<int>();
        }

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