namespace Forum.Models
{
    public class Reply
    {
        private int id;
        private string content;
        private int authorId;
        private int postId;

        public Reply(int id, string content, int authorId, int postId)
        {
            this.Id = id;
            this.Content = content;
            this.AutorId = authorId;
            this.PostId = postId;
        }

        public int PostId
        {
            get { return postId; }
            set { postId = value; }
        }


        public int AutorId
        {
            get { return authorId; }
            set { authorId = value; }
        }


        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}