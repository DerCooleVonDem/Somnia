using System.Text.RegularExpressions;

namespace Somnia.Interpreter;

public class Fileloader
{

    public string Path;
    public string FileContent;
    
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
        CleanFile();
        Path = path;
    }

    public void CleanFile()
    {
        // Remove all comments 
        // Valid Comment: # This is a comment
        FileContent = Regex.Replace(FileContent, @"#.*", "");
        //remove empty lines
        FileContent = Regex.Replace(FileContent, @"^\s*$\n", "", RegexOptions.Multiline);
    }

    public string[] GetLines()
    {
        return FileContent.Split("\n");
    }
    
    public string GetPath()
    {
        return Path;
    }
}