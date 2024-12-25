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
      switch (args.Length)
      {
        case 0:
          MainLoop();
          break;
        case 1:
          if (CheckHelpVersion(args[0]))
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
      while (running)
      {
        Console.Write("fast-notes > ");
        string? user_input = Console.ReadLine() ?? "";
        switch (user_input)
        {
          case "quit" or "q" or "exit":
            SetColor("error");
            Console.WriteLine("See you later!");
            SetColor("reset");
            running = false;
            break;
          case "help" or "h":
            HelpMessage();
            break;
          case "clear" or "c":
            Console.Clear();
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
          case "version" or "v":
            Version();
            break;
          case "banner" or "b":
            Banner();
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
      if (note_name == "")
      {
        Console.WriteLine();
        Console.Write("Note name: ");
        SetColor("noteName");
        note_name = Console.ReadLine() ?? "Unnamed";
        SetColor("reset");
      }
      if (note_content == "")
      {
        SetColor("noteName");
        Console.Write($"{note_name}");
        SetColor("reset");
        Console.Write(" content: ");
        SetColor("noteContent");
        note_content = Console.ReadLine() ?? "No content";
        SetColor("reset");
        Console.WriteLine();
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
      // MARK: GetCurrentTime
      string CurrentTime = DateTime.Now.ToString("MM/dd/yyyy");
      CheckNoteFolderExists();
      File.AppendAllText($"{NotesFolderPath()}/{note_name}", $"{CurrentTime}\n{note_content}\n\n");
    }


    // MARK: ListNotes
    static void ListNotes()
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

    // MARK: ReadNote
    static void ReadNote()
    {
      ListNotes();
      Console.Write("Enter the number of the note you want to read: ");
      SetColor("noteName");
      string? note_id_string = Console.ReadLine() ?? "";
      SetColor("reset");
      if (CheckIdExists(note_id_string))
      {
        string note_name = ConvertIdToName(note_id_string);
        Console.WriteLine();
        SetColor("noteName");
        Console.WriteLine(note_name);
        SetColor("reset");
        string[] lines = File.ReadAllLines($"{NotesFolderPath()}/{note_name}");
        SetColor("noteContent");
        foreach (string line in lines)
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
      if (CheckIdExists(note_id_string))
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
      Support Support = new();
      Support.CommandError(user_input);
    }

    // MARK: CheckHelpVersion
    static bool CheckHelpVersion(string argument)
    {
      bool is_version_or_help;
      switch (argument)
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
      Support Support = new();
      Support.SetColor(color);
    }

    // MARK: CheckNoteFolderExists
    static void CheckNoteFolderExists()
    {
      if (!Directory.Exists(NotesFolderPath()))
      {
        Directory.CreateDirectory(NotesFolderPath());
      }
    }

    // MARK: CheckNoteExists
    static bool CheckNoteExists(string note_name)
    {
      if (File.Exists($"notes/{note_name}"))
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
      Support Support = new();
      Support.HelpMessage();
    }

    // MARK: CheckIdExists
    static bool CheckIdExists(string note_id_string)
    {
      bool note_id_exists;
      if (int.TryParse(note_id_string, out int value))
      {
        int note_id_int = int.Parse(note_id_string);
        string[] notes = Directory.GetFiles(NotesFolderPath());
        if (note_id_int > notes.Length)
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
      foreach (string note in notes)
      {
        id_counter++;
        if (id_counter == note_id_int)
        {
          note_name = Path.GetFileName(note);
        }
      }
      return note_name;
    }

    // MARK: Version
    static void Version()
    {
      Support Support = new();
      Support.Version();
    }

    // MARK: NotesFolderPath()
    static string NotesFolderPath()
    {
      string notes_folder_path = $"{Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)}/.config/fastNotes/notes";
      return notes_folder_path;
    }

    // MARK: Banner
    static void Banner(bool version = false)
    {
      Support Support = new();
      Support.Banner(version);
    }
  }
}
