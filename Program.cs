using System;
using System.Collections;
using System.IO;

namespace FastNotes
{
  class Program
  {
    // MARK: Main
    static void Main(string[] args)
    {
      switch(args.Length)
      {
        case 0:
          MainLoop();
          break;
        case 1:
          if(CheckHelpVersion(args[0]))
          {
            NewNote(args[0]);
          }
          break;
        default:
          NewNote(args[0], args[1]);
          break;
      }
    }

    // MARK: MainLoop
    static void MainLoop()
    {
      bool running = true;
      SetColor("error");
      Console.WriteLine("Welcome to fast-notes! Type 'help' to get help and 'quit' to exit.");
      SetColor("reset");
      while(running)
      {
        Console.Write("fast-notes > ");
        string? user_input = Console.ReadLine() ?? "";
        switch(user_input)
        {
          case "help" or "h":
            HelpMessage();
            break;
          case "version" or "v":
            Version();
            break;
          case "clear" or "c":
            Console.Clear();
            break;
          case "quit" or "q" or "exit":
            SetColor("error");
            Console.WriteLine("See you later!");
            SetColor("reset");
            running = false;
            break;
          case "new" or "n":
            NewNote();
            break;
          case "list" or "l":
            ListNotes();
            break;
          case "read" or "r":
            ReadNote();
            break;
          case "delete" or "d":
            DeleteNote();
            break;
          default:
            CommandError(user_input);
            break;
        }
      }
    }

    // MARK: NewNote
    static void NewNote(string note_name = "", string note_content = "")
    {
      if(note_name == "")
      {
        Console.Write("Note name: ");
        SetColor("noteName");
        note_name = Console.ReadLine() ?? "Unnamed";
        SetColor("reset");
      }
      if(note_content == "")
      {
        SetColor("noteName");
        Console.Write($"{note_name}");
        SetColor("reset");
        Console.Write(" content: ");
        SetColor("noteContent");
        note_content = Console.ReadLine() ?? "No content";
        SetColor("reset");
      }
      Console.Write("Added note ");
      SetColor("noteName");
      Console.Write(note_name);
      SetColor("reset");
      Console.Write(" with content ");
      SetColor("noteContent");
      Console.WriteLine(note_content);
      SetColor("reset");
      WriteNote(note_name, note_content);
    }

    // MARK: WriteNote
    static void WriteNote(string note_name, string note_content)
    {
      CheckNoteFolderExists();
      File.AppendAllText($"{NotesFolderPath()}/{note_name}", note_content);
    }

    // MARK: ListNotes
    static void ListNotes()
    {
      CheckNoteFolderExists();
      string[] notes = Directory.GetFiles(NotesFolderPath());
      Console.WriteLine();
      if(notes.Length == 0)
      {
        Console.WriteLine("No notes found.");
      }
      int note_count = 0;
      foreach(string note in notes)
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

    // MARK: ReadNote
    static void ReadNote()
    {
      ListNotes();
      Console.Write("Enter the number of the note you want to read: ");
      SetColor("noteName");
      string? note_id_string = Console.ReadLine() ?? "";
      SetColor("reset");
      if(CheckIdExists(note_id_string))
      {
        string note_name = ConvertIdToName(note_id_string);
        Console.WriteLine();
        SetColor("noteName");
        Console.WriteLine(note_name);
        SetColor("reset");
        string[] lines = File.ReadAllLines($"{NotesFolderPath()}/{note_name}");
        SetColor("noteContent");
        foreach(string line in lines)
        {
          Console.WriteLine(line);
        }
        SetColor("reset");
        Console.WriteLine();
      }
      else
      {
        Console.WriteLine();
        Console.Write("No note found at index ");
        SetColor("noteName");
        Console.WriteLine(note_id_string);
        SetColor("reset");
        Console.WriteLine();
      }
    }

    // MARK: DeleteNote
    static void DeleteNote()
    {
      ListNotes();
      Console.Write("Enter the number of the note you want to delete: ");
      SetColor("noteName");
      string? note_id_string = Console.ReadLine() ?? "";
      SetColor("reset");
      if(CheckIdExists(note_id_string))
      {
        string note_name = ConvertIdToName(note_id_string);
        Console.WriteLine();
        SetColor("noteName");
        Console.WriteLine(note_name);
        SetColor("reset");
        File.Delete($"{NotesFolderPath()}/{note_name}");
        Console.WriteLine($"Deleted ");
        Console.WriteLine();
      }
      else
      {
        Console.WriteLine();
        Console.Write("No note found at index ");
        SetColor("noteName");
        Console.WriteLine(note_id_string);
        SetColor("reset");
        Console.WriteLine();
      }
    }

    // MARK: CommandError
    static void CommandError(string user_input)
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

    // MARK: CheckHelpVersion
    static bool CheckHelpVersion(string argument)
    {
      bool is_version_or_help;
      switch(argument)
      {
        case "--version" or "-v" or "version":
          Version();
          is_version_or_help = true;
          break;
        case "--help" or "-h" or "help":
          HelpMessage();
          is_version_or_help = true;
          break;
      }
      is_version_or_help = false;
      return is_version_or_help;
    }

    // MARK: SetColor
    static void SetColor(string color)
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

    // MARK: CheckNoteFolderExists
    static void CheckNoteFolderExists()
    {
      if(!Directory.Exists(NotesFolderPath()))
      {
        Directory.CreateDirectory(NotesFolderPath());
      }
    }
    
    // MARK: CheckNoteExists
    static bool CheckNoteExists(string note_name)
    {
      if(File.Exists($"notes/{note_name}"))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    // MARK: HelpMessage
    static void HelpMessage()
    {
      string[] commands = {"quit", "new", "list", "read", "delete", "clear", "version"};
      string[] actions = {"exits the program", "creates a new note", "lists all notes", "reads a note", "deletes a note", "clears the console", "displays the version of Fast-notes"};

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
    }

    // MARK: CheckIdExists
    static bool CheckIdExists(string note_id_string)
    {
      bool note_id_exists;
      if(int.TryParse(note_id_string, out int value))
      {
        int note_id_int = int.Parse(note_id_string);
        string[] notes = Directory.GetFiles(NotesFolderPath());
        if(note_id_int > notes.Length)
        {
          note_id_exists = false;
        }
        else
        {
          note_id_exists = true;
        }
      }
      else
      {
        Console.WriteLine("You have to enter a number");
        note_id_exists = false;
      }
      return note_id_exists;
    }

    // MARK: ConvertIdToName
    static string ConvertIdToName(string note_id_string)
    {
      int note_id_int = int.Parse(note_id_string);
      int id_counter = 0;
      string note_name = "";
      string[] notes = Directory.GetFiles(NotesFolderPath());
      foreach(string note in notes)
      {
        id_counter++;
        if(id_counter == note_id_int)
        {
          note_name = Path.GetFileName(note);
        }
      }
      return note_name;
    }

    // MARK: Version
    static void Version()
    {
      SetColor("error");
      Console.Write("Fast-notes");
      SetColor("reset");
      Console.Write(" version ");
      SetColor("error");
      Console.WriteLine("0.3.1");
      SetColor("reset");
    }

    // MARK: NotesFolderPath()
    static string NotesFolderPath()
    {
      string notes_folder_path = $"{Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)}/.config/fastNotes/notes";
      return notes_folder_path;
    }
  }
}
