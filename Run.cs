using ProgrammingLearningApp;

public class Run
{
    private static void Main(string[] args)
    {
        Application app = new Application();

        while(true)
        {

            Console.WriteLine("Select a program: (Type the filename (including extension), or 'random' to get a random program)");
            string file = Console.ReadLine();

            if(file == "random")
            {
                file = getrandomfile2("../../../Programs");
            }


            Console.WriteLine("Type the number '1' to execute the program. Type the number '2' to view the program's metrics.");
            string mode = Console.ReadLine();
            int modeInt;
            bool validNumber = int.TryParse(mode, out modeInt);

            if(!validNumber || (modeInt != 1 && modeInt != 2))
            {
                ShowError("Invalid mode. Try again.");
                continue;
            }

            try
            {
                if (modeInt == 1)
                {
                    app.RunProgram(file);
                }
                else if (modeInt == 2)
                {
                    app.ShowMetrics(file);
                }
            }
            catch (FileNotFoundException)
            {
                ShowError("File not found. Try again.");
                continue;
            }
            catch (Exception)
            {
                ShowError("File invalid. Try again.");
                continue;
            }

        }
    }

    static void ShowError(string error)
    {
        Console.Clear();
        Console.WriteLine(error);
    }

    /// <summary>
    /// Code to get a random file from a directory.
    /// 
    /// Method slightly modified from: https://stackoverflow.com/questions/742685/select-random-file-from-directory
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static string getrandomfile2(string path)
    {
        string file = null;
        if (!string.IsNullOrEmpty(path))
        {
            var extensions = new string[] { ".txt" };
            try
            {
                var di = new DirectoryInfo(path);
                var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                Random R = new Random();
                file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).Name;  //Modified slightly here: Name instead of FullName
            }
            // probably should only catch specific exceptions
            // throwable by the above methods.
            catch { }
        }
        return file;
    }
}