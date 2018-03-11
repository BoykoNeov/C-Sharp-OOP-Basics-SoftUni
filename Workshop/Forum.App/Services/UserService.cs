namespace Forum.App.Services
{
    using System;
    using System.Linq;
    using Forum.Data;
    using Forum.Models;
    using static Forum.App.Controllers.SignUpController;

    public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users.Any(u => u.Name == username && u.Password == password);

            return userExists;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users.Any(u => u.Name == username && u.Password == password);

            if (!userExists)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username, password);
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }

        internal static User GetUserById(int userId)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Id == userId);
            return user;
        }

        internal static User GetUserByName(string author)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Name == author);
            return user;
        }
    }
}