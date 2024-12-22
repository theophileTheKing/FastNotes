namespace FastNotes
{
    public class Support
    {
      public void HelpMessage()
      {
        Console.WriteLine();
        SetColor("error");
        Console.WriteLine("fastNote");
        SetColor("reset");
        Console.WriteLine("version 0.3.1");
        Console.WriteLine();
        Console.WriteLine("Welcome to fastNote ! A simple CLI tool to take notes easily");
        Console.Write("Usage : ");
        SetColor("error");
        Console.Write("fastNote");
        SetColor("reset");
        Console.WriteLine(" [command] [argument]");
        Console.WriteLine();

        
        // commands in the CLI
        string[] commands = ["quit", "new", "list", "read", "delete", "clear", "version"];
        string[] actions = ["exits the program", "creates a new note", "lists all notes", "reads a note", "deletes a note", "clears the console", "displays the version of Fast-notes"];

        Console.WriteLine();
        Console.WriteLine("Available commands:");

        for(int i = 0; i < commands.Length; i++)
        {
          SetColor("error");
          Console.Write(commands[i]);
          SetColor("reset");
          Console.WriteLine($" - {actions[i]}");
        }
        Console.WriteLine();

        // commands
        Console.WriteLine("[OPTIONS]");
        Console.WriteLine("--version, -v Show version information.");
        Console.WriteLine("--help, -h Show this help message and exit.");
      }

      // MARK: Version
      public void Version()
      {
        SetColor("error");
        Console.Write("Fast-notes");
        SetColor("reset");
        Console.Write(" version ");
        SetColor("error");
        Console.WriteLine("0.3.1");
        SetColor("reset");
      }

      // MARK: CommandError
      public void CommandError(string user_input)
      {
        Console.Write("The command ");
        SetColor("error");
        Console.Write(user_input);
        SetColor("reset");
        Console.Write(" does not exist. Type ");
        SetColor("error");
        Console.Write("help");
        SetColor("reset");
        Console.WriteLine(" to get help.");
      }

      // MARK: SetColor
      public void SetColor(string color)
      {
        switch(color)
        {
          case "noteName":
            Console.ForegroundColor = ConsoleColor.Red;
            break;
          case "noteContent":
            Console.ForegroundColor = ConsoleColor.Cyan;
            break;
          case "error":
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            break;
          case "reset":
            Console.ResetColor();
            break;
        }
      }
    }
}
