using Somnia.Interpreter.Tokens;

namespace Somnia.Interpreter;

public class Interpreter
{

    public string Path;
    public Fileloader Fileloader;
    public TokenManager TokenManager;
    
    public Interpreter(string path)
    {
        Path = path;
        Fileloader = new Fileloader(path);
        TokenManager = new TokenManager();
    }
    
    public bool ExecLine(string line, int lineNum, string where)
    {
        //Split the id and the body
        //Example: PRINT "Hello World"
        //id = PRINT
        //body = "Hello World"
        string id = line.Split(' ')[0];
        string body = line.Substring(id.Length + 1);

        if (!TokenManager.RunToken(id, body, lineNum, where))
        {
            Environment.Exit(1);
        }
        
        return true;
    }

    public void Run()
    {
        string[] lines = Fileloader.GetLines();
        
        int currentLine = 0;
        //Debug Lines
        //While there are lines to read
        while (currentLine < lines.Length)
        {
            //Read the line
            string line = lines[currentLine];
            //If the line is not empty
            if (line != "")
            {
                //If the line is not a comment
                if (line[0] != '#')
                {
                    //Execute the line
                    ExecLine(line, currentLine, Fileloader.GetPath());
                }
            }
            //Go to the next line
            currentLine++;
        }
    }
    
}