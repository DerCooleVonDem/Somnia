namespace Somnia.Interpreter;

public class Interpreter
{

    public string Path;
    public Fileloader Fileloader;
    
    public Interpreter(string path)
    {
        Path = path;
        Fileloader = new Fileloader(path);
    }

    public void Run()
    {
        string[] lines = Fileloader.GetLines();
        
        //Debug Lines
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
    
}