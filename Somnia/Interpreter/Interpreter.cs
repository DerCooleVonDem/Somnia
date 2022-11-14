using Somnia.Interpreter.Tokens;

namespace Somnia.Interpreter;

public class Interpreter
{

    public string Path;
    public Fileloader Fileloader;
    public TokenManager TokenManager;
    
    public static Interpreter Instance;
    
    public Interpreter(string path)
    {
        Path = path;
        Fileloader = new Fileloader(path);
        TokenManager = new TokenManager();
        Instance = this;
    }
    
    public static Interpreter GetInstance()
    {
        return Instance;
    }
    
    public bool ExecLine(string line, int lineNum, string where)
    {
        //Split the id and the body
        //Example: PRINT "Hello World"
        //id = PRINT
        //body = "Hello World"
        string id = line.Split(' ')[0];
        string body = "";
        if(id.Length + 1 < line.Length)
        {
            body = line.Substring(id.Length + 1);
        }


        if (!TokenManager.RunToken(id, body, lineNum, where))
        {
            Environment.Exit(1);
        }
        
        return true;
    }

    public string[] lines = new string[0];
    
    public int currentLine = 0;
    public bool gotGoto = false;

    public void Run()
    {

        lines = Fileloader.GetLines();

        //Debug Lines
        //While there are lines to read
        while (currentLine < lines.Length)
        {
            
            if(Fileloader.SkipLine(currentLine)) { currentLine++; continue; }
            
            gotGoto = false;
            
            //Read the line
            string line = lines[currentLine].Trim();
            
            //Execute the line
            ExecLine(line, currentLine, Fileloader.GetPath());

            //Go to the next line
            if(!gotGoto) currentLine++;
        }
    }
    
    public void GotoLine(int line)
    {

        if (line == -1)
        {
            Environment.Exit(0);    
        }
        
        currentLine = line;
        gotGoto = true;
    }
}