namespace Forum.App.Controllers
{
    using System;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;

    public class LogInController : IController, IReadUserInfoController
    {
        public string Username { get; private set; }
        private string Password { get; set; }
        private bool Error { get; set; }

        public enum Command
        {
            ReadUsername, ReadPassword, LogIn, Back
        }

        public LogInController()
        {
            this.ResetLogin();
        }

        private void ResetLogin()
        {
            this.Error = false;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Login;

                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Login;

                case Command.LogIn:
                    bool loggedIn = UserService.TryLogInUser(this.Username, this.Password);
                    if (loggedIn)
                    {
                        return MenuState.SuccessfulLogIn;
                    }
                    else
                    {
                        this.Error = true;
                    }

                    return MenuState.Error;

                case Command.Back:
                    return MenuState.Back;

                default: throw new InvalidOperationException();
            }
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void Back()
        {
            ResetLogin();
        }
    }
}