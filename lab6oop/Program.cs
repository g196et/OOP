using Humans;

namespace Commands {

    internal class Program {

        private static void Main (string[] args) {
            Application app = new Application();
            app.AddCommand(new HelpCommand(app));
            app.AddCommand(new ExplainCommand(app));
            app.AddCommand(new PushCommand<Human>(app));
            app.AddCommand(new PopCommand<Human>(app));
            app.AddCommand(new ShiftCommand<Human>(app));
            app.AddCommand(new UnshiftCommand<Human>(app));
            app.AddCommand(new PrintCommand<Human>(app));
            app.AddCommand(new LoadCommand<Human>(app));
            app.AddCommand(new GetIndexCommand<Human>(app));
            app.AddCommand(new EditCommand<Human>(app));
            app.AddCommand(new ExitCommand(app));
            app.Run();
        }
    }
}