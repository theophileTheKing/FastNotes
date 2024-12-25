namespace FastNotes
{
  public class TrashSupport
  {
    // MARK: TrashHelpMessage
    public void TrashHelpMessage()
    {
      Banner(true);

      Console.WriteLine();
      Console.WriteLine("You are in fastNote's trash, here you can find and restore deleted notes");
      Console.WriteLine();

      SetColor("error");
      Console.WriteLine("[OPTIONS]");
      SetColor("reset");
      Console.WriteLine("quit, q     Quit the fastNote's trash");
      Console.WriteLine("help, h     Show this help message and exit");
      Console.WriteLine("clear, c    Clear the CLI");
      Console.WriteLine();
      Console.WriteLine("list, l     List all of your notes and give them an ID");
      Console.WriteLine("restore, r  Restore a note, you can enter the note's ID or you will be prompted to enter it");
      Console.WriteLine("delete, d   Delete a note forever, you can enter the note's ID or you will be prompted to enter it");
      Console.WriteLine("wipe, w     Wipe the entire trash, you will not be able to restore any note after that");
      Console.WriteLine();
      Console.WriteLine("version, v  Show version information");
      Console.WriteLine("banner, b   Show the fastNote banner");
      Console.WriteLine("update      Check for updates, if there are, prompts you to install them");
      Console.WriteLine();
    }

    // MARK: TrashCommandError
    public void TrashCommandError(string user_input)
    {
      Console.Write("The command ");
      SetColor("error");
      Console.Write(user_input);
      SetColor("reset");
      Console.Write(" does not exist in the trash. Type ");
      SetColor("error");
      Console.Write("help");
      SetColor("reset");
      Console.WriteLine(" to get help.");
    }

    // MARK: CheckTrashFolderExists
    public void CheckTrashFolderExists()
    {
      if (!Directory.Exists(TrashFolderPath()))
      {
        Directory.CreateDirectory(TrashFolderPath());
      }
    }

    // MARK: TrashFolderPath()
    public string TrashFolderPath()
    {
      string trash_folder_path = $"{Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)}/.config/fastNotes/trash";
      return trash_folder_path;
    }

    // MARK: Banner
    static void Banner(bool version)
    {
      Support Support = new();
      Support.Banner(version);
    }

    // MARK: SetColor
    static void SetColor(string color)
    {
      Support Support = new();
      Support.SetColor(color);
    }
  }
}
