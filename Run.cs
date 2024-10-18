using ProgrammingLearningApp;

public class Run
{
    private static void Main(string[] args)
    {
        Application app = new Application();

        while(true)
        {
            // Get the program
            Console.WriteLine("Select a program: Type the filename (including extension), 'random' to get a random program, or a number (0-5) for a hard-coded program");
            string file = Console.ReadLine();

            if(file == "random")
            {
                file = GetRandomFile("../../../Programs");
            }


            // Get whether we should execute the program or show its metrics
            Console.WriteLine("Type the number '1' to execute the program. Type the number '2' to view the program's metrics.");
            string mode = Console.ReadLine();
            int modeInt;
            bool validNumber = int.TryParse(mode, out modeInt);

            if(!validNumber || (modeInt != 1 && modeInt != 2))
            {
                ShowError("Invalid mode. Try again.");
                continue;
            }


            // If the given file/program is suitable, run the program or show the metrics; otherwise, show the appropriate error.
            int hardcodedNr;
            bool hardcodedProgram = int.TryParse(file, out hardcodedNr);
            try
            {
                if (modeInt == 1)
                {
                    if (hardcodedProgram)
                        app.RunProgram(hardcodedNr);
                    else
                        app.RunProgram(file);
                }
                else if (modeInt == 2)
                {
                    if (hardcodedProgram)
                        app.ShowMetrics(hardcodedNr);
                    else
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
    private static string GetRandomFile(string path)
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