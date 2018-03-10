using System;
using System.Collections.Generic;
using Forum.Models;

namespace Forum.Data
{
    public class ForumData
    {
        public List<Category> Categories { get; set; }

        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }

        public List<Reply> Replies { get; set; }

        public ForumData()
        {
            //Test Initialize
            //InitializeWithTestDate();

            this.Users = DataMapper.ListUsers();
            this.Categories = DataMapper.LoadCategories();
            this.Posts = DataMapper.LoadPosts();
            this.Replies = DataMapper.LoadReplies();
        }

        //private void InitializeWithTestDate()
        //{
        //    DataMapper.SaveUsers(new List<User> { new User(0, "testUser", "test", new List<int>() { 0 }) });
        //    DataMapper.SaveCategories(new List<Category> { new Category(0, "PyrvaKategoriq", new int[] { 0 }) });
        //    DataMapper.SavePosts(new List<Post> { new Post(0, "Zaglavie", "Sydyrjanie", 0, 0, new List<int>() { 0 }) });
        //    DataMapper.SaveReplies(new List<Reply> { new Reply(0, "Replai!", 0, 0) });

        //    this.SaveChanges();
        //}

        public void SaveChanges()
        {
            DataMapper.SaveUsers(this.Users);
            DataMapper.SavePosts(this.Posts);
            DataMapper.SaveReplies(this.Replies);
            DataMapper.SaveCategories(this.Categories);
        }
    }
}