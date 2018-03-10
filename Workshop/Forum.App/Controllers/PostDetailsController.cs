namespace Forum.App.Controllers
{
    using System;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;
    using ForumSystem.Services;

    public class PostDetailsController : IController, IUserRestrictedController
    {
        private enum Command
        {
            Back, Reply
        }

        public bool LoggedInUser { get; set; }
        public int PostId { get; private set; }

        public void SetPostId(int postId)
        {
            this.PostId = postId;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Reply:
                    return MenuState.AddReplyToPost;

                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;

                default:
                    throw new InvalidCommandException();
            }
        }

        public IView GetView(string userName)
        {
            PostViewModel postViewModel = PostService.GetPostViewModel(this.PostId);
            return new PostDetailsView(postViewModel, this.LoggedInUser);
        }

        public void UserLogIn()
        {
            this.LoggedInUser = true;
        }

        public void UserLogOut()
        {
            this.LoggedInUser = false;
        }
    }
}
