using Forum.Data;

namespace Forum.App
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            ForumData forumData = new ForumData();

			Engine engine = new Engine();
			engine.Run();
		}
	}
}