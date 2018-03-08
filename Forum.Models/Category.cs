namespace Forum.Models
{
    using System;
    using System.Collections.Generic;

    public class Category
    {
        private int id;
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
    }
}