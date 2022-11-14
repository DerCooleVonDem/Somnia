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
        if (!TokenManager.RunToken(line, lineNum, where))
        {
            Environment.Exit(1);
        }
        return true;
    }

    public string[] lines = new string[0];
    
    public int currentLine = 0;
    public bool gotGoto = false;
    
    public bool skipToNextBreak = false;

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
            
            if(skipToNextBreak && line != "break")
            {
                currentLine++;
                continue;
            }
            
            if(line == "break")
            {
                skipToNextBreak = false;
                currentLine++;
                continue;
            }
            
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
    
    public void SkipToNextBreak()
    {
        skipToNextBreak = true;
    }
}