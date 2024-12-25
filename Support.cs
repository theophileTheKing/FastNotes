namespace FastNotes
{
  public class Support
  {

    // MARK: HelpMessage
    public void HelpMessage()
    {
      Banner(true);

      Console.WriteLine();
      Console.WriteLine("Welcome to fastNote ! A simple CLI tool to take notes easily");
      Console.WriteLine();
      Console.WriteLine("Usage :");
      Console.Write("fastNote");
      SetColor("error");
      Console.WriteLine(" [OPTIONS] [SHORTCUTS]");
      SetColor("reset");
      Console.WriteLine();

      Console.WriteLine("Using fastNote without any options starts the fastNote CLI, you can either add a [CONSOLE OPTION] or a [SHORTCUTS]");
      Console.WriteLine();

      SetColor("error");
      Console.WriteLine("[CLI OPTIONS]");
      SetColor("reset");
      Console.WriteLine("quit, q     Quit the program");
      Console.WriteLine("help, h     Show this help message and exit");
      Console.WriteLine("clear, c    Clear the CLI");
      Console.WriteLine();
      Console.WriteLine("new, n      Create a new note, you will be prompted for the note's name and content");
      Console.WriteLine("list, l     List all of your notes and give them an ID");
      Console.WriteLine("read, r     Read a note, you can enter the note's ID or you will be prompted to enter it");
      Console.WriteLine("delete, d   Delete a note, you can enter the note's ID or you will be prompted to enter it");
      Console.WriteLine();
      Console.WriteLine("version, v  Show version information");
      Console.WriteLine("banner, b   Show the fastNote banner");
      Console.WriteLine("update      Check for updates, if there are, prompts you to install them");
      Console.WriteLine();

      SetColor("error");
      Console.WriteLine("[CONSOLE OPTIONS]");
      SetColor("reset");
      Console.WriteLine("--version, -v  Show version information.");
      Console.WriteLine("--help, -h     Show this help message and exit.");
      Console.WriteLine();

      SetColor("error");
      Console.WriteLine("[SHORTCUTS]");
      SetColor("reset");
      Console.WriteLine("fastNote {note_title} : To take a note very quickly you can pass to fastNotes one or two arguments : the first argument will be taken as the title of your note, and you will be prompted to enter a content in your note");
      Console.WriteLine("    eg : fastNote myNote");
      Console.WriteLine();
      Console.WriteLine("fastNote {note_title} {note_content} : To take a really quick note you can enter as a second argument the content of your note (between parenthesis for multiple words)");
      Console.WriteLine("    eg : fastNote myNote 'the content of myNote'");
      Console.WriteLine();
    }

    // MARK: Version
    public void Version()
    {
      Banner(true);
    }

    // MARK: Banner
    public void Banner(bool version = false)
    {
      Console.WriteLine();
      SetColor("error");
      Console.WriteLine("  _____                 __   _______          __               ");
      Console.WriteLine("_/ ____\\____    _______/  |_ \\      \\   _____/  |_  ____  ");
      Console.WriteLine("\\   __\\\\__  \\  /  ___/\\   __\\/   |   \\ /  _ \\   __\\/ __ \\ ");
      Console.WriteLine(" |  |   / ___\\_\\___ \\  |  | /    |    (  <_> )  | \\  ___/");
      Console.WriteLine(" |__|  (____  /____  > |__| \\____|__  /\\____/|__|  \\___  >");
      if (version)
      {
        Console.Write("            \\/       \\/     \\/               \\/        \\/");
        Console.WriteLine("    Version 0.3.1");
        Console.WriteLine();
        Console.WriteLine("https://github.com/theophileTheKing/FastNotes");
      }
      else
      {
        Console.WriteLine("            \\/       \\/     \\/               \\/        \\/");
      }
      Console.WriteLine("");
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
      switch (color)
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
