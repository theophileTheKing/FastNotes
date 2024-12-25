namespace FastNotes
{
  public class TrashProgram
  {
    public void Trash()
    {
      // MARK: MainLoop
      bool running = true;
      while (running)
      {
        Console.Write("fast-notes");
        SetColor("error");
        Console.Write(" (trash)");
        SetColor("reset");
        Console.Write(" > ");
        string? user_input = Console.ReadLine() ?? "";
        switch (user_input)
        {
          case "quit" or "q" or "exit":
            SetColor("error");
            Console.WriteLine("You quit the trash");
            SetColor("reset");
            running = false;
            break;
          case "help" or "h":
            TrashHelpMessage();
            break;
          case "clear" or "c":
            Console.Clear();
            break;
          case "list" or "l":
            TrashListNotes();
            break;
          // case "restore" or "r":
          //   TrashRestore();
          //   break;
          // case "delete" or "d":
          //   TrashDelete();
          //   break;
          // case "wipe" or "w":
          //   TrashWipe();
          //   break;
          case "version" or "v":
            Banner(true);
            break;
          case "banner" or "b":
            Banner(false);
            break;
          default:
            TrashCommandError(user_input);
            break;
        }
      }
    }

    // MARK: ListNotes
    static void TrashListNotes()
    {
      CheckNoteFolderExists();
      string[] notes = Directory.GetFiles(NotesFolderPath());
      Console.WriteLine();
      if (notes.Length == 0)
      {
        Console.WriteLine("No notes found.");
      }
      int note_count = 0;
      foreach (string note in notes)
      {
        note_count++;
        SetColor("noteName");
        Console.Write($" {note_count} ");
        SetColor("reset");
        Console.Write("- ");
        Console.WriteLine(Path.GetFileName(note));
      }
      Console.WriteLine();
    }

    // MARK: CheckNoteFolderExists
    static void CheckNoteFolderExists()
    {
      if (!Directory.Exists(NotesFolderPath()))
      {
        Directory.CreateDirectory(NotesFolderPath());
      }
    }

    // MARK: NotesFolderPath()
    static string NotesFolderPath()
    {
      Support Support = new();
      return Support.NotesFolderPath();
    }

    // MARK: CheckTrashFolderExists
    static void CheckTrashFolderExists()
    {
      if (!Directory.Exists(TrashFolderPath()))
      {
        Directory.CreateDirectory(TrashFolderPath());
      }
    }

    // MARK: TrashFolderPath()
    static string TrashFolderPath()
    {
      string trash_folder_path = $"{Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)}/.config/fastNotes/trash";
      return trash_folder_path;
    }

    // MARK: SetColor
    static void SetColor(string color)
    {
      Support Support = new();
      Support.SetColor(color);
    }

    // MARK: HelpMessage
    static void TrashHelpMessage()
    {
      TrashSupport TrashSupport = new();
      TrashSupport.TrashHelpMessage();
    }

    // MARK: CommandError
    static void TrashCommandError(string user_input)
    {
      TrashSupport TrashSupport = new();
      TrashSupport.TrashCommandError(user_input);
    }

    // MARK: Banner
    static void Banner(bool version)
    {
      Support Support = new();
      Support.Banner(version);
    }
  }
}
