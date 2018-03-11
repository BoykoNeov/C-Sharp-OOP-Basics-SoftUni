namespace BashSoft
{
    using BashSoft.IO;

    public class Launcher
    {
        public static void Main()
        {
            Tester tester = new Tester();
            IOManager iOManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, iOManager);
            InputReader reader = new InputReader(currentInterpreter);
            reader.StartReadingCommands();

        }
    }
}