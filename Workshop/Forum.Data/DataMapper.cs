namespace Forum.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Forum.Models;

    public class DataMapper
    {
        private const string DATA_PATH = "../data/";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        public static List<Category> LoadCategories()
        {
            if (!config.ContainsKey("categories"))
            {
                config.Add("categories", "categories.csv");
            }

            List<Category> categories = new List<Category>();
            string[] dataLines = ReadLines(config["categories"]);

            foreach (string line in dataLines)
            {
                string[] args = line.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(args[0]);
                string name = args[1];
                int[] postIds = args[2].Split(',', System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Category category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (Category category in categories)
            {
                const string CATEGORY_FORMAT = "{0};{1};{2}";
                string line = string.Format(CATEGORY_FORMAT, category.Id, category.Name, string.Join(",", category.PostIds));
                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            if (!config.ContainsKey("posts"))
            {
                config.Add("posts", "posts.csv");
            }

            List<Post> posts = new List<Post>();
            string[] dataLines = ReadLines(config["posts"]);

            foreach (string line in dataLines)
            {
                // 1;bbbb;bbbbb,1,1

                string[] args = line.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(args[0]);
                string title = args[1];
                string content = args[2];
                int categoryId = int.Parse(args[3]);
                int authorId = int.Parse(args[4]);

                List<int> replyIds = new List<int>();

                if (args.Length > 5)
                {
                    replyIds = args[5].Split(',', System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                }

                Post post = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (var post in posts)
            {
                const string POST_FORMAT = "{0};{1};{2};{3};{4};{5}";
                string line = string.Format(POST_FORMAT, post.Id, post.Title, post.Content, post.CategoryId, post.AuthorId, string.Join(",", post.ReplyIds));
                line = line.TrimEnd(',');
                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<User> ListUsers()
        {
            List<User> users = new List<User>();

            if (!config.ContainsKey("users"))
            {
                config.Add("users", "users.csv");
            }

            string[] dataLines = ReadLines(config["users"]);

            foreach (string line in dataLines)
            {
                string[] args = line.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(args[0]);
                string name = args[1];
                string password = args[2];
                List<int> postIds = new List<int>();

                if (args.Length > 3)
                {
                    postIds = args[3].Split(',', System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                }
                else
                {
                    password = password.TrimEnd(',');
                }

                User user = new User(id, name, password, postIds);
                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (var user in users)
            {
                const string USER_FORMAT = "{0};{1};{2},{3}";
                string line = string.Format(USER_FORMAT, user.Id, user.Name, user.Password, string.Join(",", user.PostIds));
                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }


        public static List<Reply> LoadReplies()
        {
            if (!config.ContainsKey("replies"))
            {
                config.Add("replies", "replies.csv");
            }

            List<Reply> replies = new List<Reply>();
            string[] dataLines = ReadLines(config["replies"]);

            foreach (string line in dataLines)
            {
                string[] args = line.Split(";", System.StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(args[0]);
                string content = args[1];
                int authorId = int.Parse(args[2]);
                int postId = int.Parse(args[3]);
                var reply = new Reply(id, content, authorId, postId);
                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (var reply in replies)
            {
                const string REPLY_FORMAT = "{0};{1};{2};{3}";
                string line = string.Format(REPLY_FORMAT, reply.Id, reply.Content, reply.AutorId, reply.PostId);
                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }

        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            string[] contents = ReadLines(configPath);

            Dictionary<string, string> config = contents.Select(l => l.Split('=')).ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            string[] lines = File.ReadAllLines(path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}