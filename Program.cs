namespace Console_menu
{
    public class Program : Menu
    {
        private static void Main(string[] args)
        {
            Options = new List<Option>
            {
                new("View assignments", ChooseAssignment),
                new("Help", () => Console.WriteLine(HelpText())),
                new("Exit", () => Environment.Exit(0)),
            };
            
            var index = 0;
            WriteMenu(Options, Options[index]);


            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                switch (keyinfo.Key)
                {
                    case ConsoleKey.DownArrow:
                    {
                        if (index + 1 < Options.Count)
                        {
                            index++;
                            WriteMenu(Options, Options[index]);
                        }
                        break;
                    }

                    case ConsoleKey.UpArrow:
                    {
                        if (index - 1 >= 0)
                        {
                            index--;
                            WriteMenu(Options, Options[index]);
                        }
                        break;
                    }

                    case ConsoleKey.Enter:
                        Options[index].Selected.Invoke();
                        index = 0;
                        break;
                    case ConsoleKey.Escape:
                        Main(Array.Empty<string>());
                        break;
                }
            } while (keyinfo.Key != ConsoleKey.X);
            Console.ReadKey(true);
        }

        private static void WriteMenu(List<Option> options, Option selectedOption) 
        {
            Console.Clear();
            foreach(var option in options)
            {
                Console.Write(option == selectedOption ? @"> " : @" ");
                Console.WriteLine(option.Name);
            }
        }

        private static void ChooseAssignment() 
        {
            Console.Clear();
            Options = new List<Option>
            {
                new("Ukesoppgave 1", () => Console.WriteLine("Not implemented")),
                new("Ukesoppgave 2", () => Console.WriteLine("Not implemented")),
                new("Ukesoppgave 3", () => Console.WriteLine("Not implemented")),
                new("Ukesoppgave 4", () => Console.WriteLine("Not implemented"))
                //new("Ukesoppgave 5", () => UkesOppgaveFem())
            };

            var index = 0;
            WriteMenu(Options, Options[index]);
        }

        private static string HelpText()
        {
            string[] allCommands =
            {
                "'Next menu' to go to the next menu.",
                "'Help' to view a list of all available commands.",
                "'Exit' to exit the application"
            };

            var availableCommands = allCommands.Aggregate("", (current, command) => current + ("    " + command + "\n"));
            Console.Clear();
            return "Available commands:\n" + availableCommands;
        }
    }
}
