namespace ForumSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.Data;
    using Forum.Models;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Services;

    public static class PostService
    {
        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(p => p.Id == postId);
            PostViewModel postViewModel = new PostViewModel(post);
            return postViewModel;
        }

        public static Category GetCategoryById(int categoryId)
        {
            ForumData forumData = new ForumData();
            Category category = forumData.Categories.Find(c => c.Id == categoryId);
            return category;
        }

        public static IList<ReplyViewModel> GetPostRepliesById(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (int replyId in post.ReplyIds)
            {
                Reply reply = forumData.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            var postIds = forumData.Categories.First(c => c.Id == categoryId).PostIds;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();
            var allCategories = forumData.Categories.Select(c => c.Name).ToArray();
            return allCategories;
        }

        internal static bool TrySavePost(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            bool emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyContent || emptyTitle)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            Category category = EnsureCategory(postView, forumData);
            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;
            var author = UserService.GetUserByAuthor(postView.Author);
            var authorId = author.Id;
            string content = string.Join(string.Empty, postView.Content);

            var post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            postView.PostId = postId;

            return true;
        }
    }
}