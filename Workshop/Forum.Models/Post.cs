namespace Forum.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Post
    {
        private int id;
        private string title;
        private string content;
        private int categoryId;
        private int authorId;
        private ICollection<int> replyIds;

        public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replyIds)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
            this.ReplyIds = replyIds.ToList();
        }

        public ICollection<int> ReplyIds
        {
            get { return replyIds; }
            set { replyIds = value; }
        }


        public int AuthorId
        {
            get { return authorId; }
            set { authorId = value; }
        }


        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }


        public string Content
        {
            get { return content; }
            set { content = value; }
        }


        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
