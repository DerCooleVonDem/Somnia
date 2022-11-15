using System.Text.RegularExpressions;

namespace Somnia.Interpreter;

public class Fileloader
{

    public string Path;
    public string FileContent;
    public List<int> skipLines = new List<int>();

    public Fileloader(string path)
    {
        //if the path is a directory, load the first file named Start.som
        if (Directory.Exists(path))
        {
            path = System.IO.Path.Combine(path, "Start.som");
        }
        //if the file doesn't exist, throw an exception
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File not found", path);
        }
        //load the file
        FileContent = File.ReadAllText(path);
        ScanFile();
        Path = path;
    }

    public void ScanFile()
    {
        string[] lines  = GetLines();
        
        //remove comments and empty lines
        //Valid comment: # comment
        
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            if (line.Trim().StartsWith("#") || line == "")
            {
                skipLines.Add(i);
            }
        }
    }

    public string[] GetLines()
    {
        return FileContent.Split("\n");
    }
    
    public bool SkipLine(int line)
    {
        return skipLines.Contains(line);
    }

    public string GetPath()
    {
        return Path;
    }
}