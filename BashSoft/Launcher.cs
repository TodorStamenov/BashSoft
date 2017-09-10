namespace BashSoft
{
    using Contracts;
    using IO;
    using Judge;
    using Repository;

    public class Launcher
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDataSorter sorter = new RepositorySorter();
            IDataFilter filter = new RepositoryFilter();

            IDatabase repo = new StudentsRepository(sorter, filter);

            IInterpreter commandInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(commandInterpreter);

            reader.StartReadingCommands();
        }
    }
}