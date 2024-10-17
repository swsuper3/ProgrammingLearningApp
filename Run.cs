using ProgrammingLearningApp;

public class Run
{
    private static void Main(string[] args)
    {
        ProgramLoader pl = new ProgramLoader();
        Program p = pl.CreateProgram("basic1.txt");

        Character character = new Character();

        Console.WriteLine(character.Position);

        p.Execute(character);

        Console.WriteLine(character.Position + ": facing "+character.ViewDirection);

    }
}