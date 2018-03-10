namespace Forum.App.UserInterface.ViewModels
{
    using Forum.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.Services;
    using ForumSystem.Services;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        public PostViewModel()
        {
        }

        public PostViewModel(Post post)
        {
            this.PostId = post.Id;
            this.Title = post.Title;
            this.Author = UserService.GetUserById(PostId).Name;
            this.Category = PostService.GetCategoryById(post.CategoryId).Name;
            this.Content = GetLines(post.Content);
            this.Replies = PostService.GetPostRepliesById(post.Id);
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; } = new List<string>();

        public IList<ReplyViewModel> Replies { get; set; } = new List<ReplyViewModel>();

        //private IList<ReplyViewModel> ConvertReplyServiceModels(IList<ReplyServiceModel> replies)
        //{
        //    var replyViewModels = new List<ReplyViewModel>();

        //    foreach (var rsm in replies)
        //    {
        //        replyViewModels.Add(new ReplyViewModel(rsm));
        //    }

        //    return replyViewModels;
        //}

        private IList<string> GetLines(string content)
        {
            var contentSymbols = content.ToCharArray();

            var lines = new List<string>();

            for (int symbol = 0; symbol < content.Length; symbol += LINE_LENGHT)
            {
                var currentRow = contentSymbols.Skip(symbol).Take(LINE_LENGHT).ToArray();

                string rowAsString = string.Join(string.Empty, currentRow);

                lines.Add(rowAsString);
            }

            return lines;
        }
    }
}
