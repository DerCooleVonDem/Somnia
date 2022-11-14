using System.Text.RegularExpressions;

namespace Somnia.Interpreter;

public class Fileloader
{

    public string fileContent;
    
    public Fileloader(string path)
    {
        //if the path is a directory, load the first file named Start.som
        if (Directory.Exists(path))
        {
            path = Path.Combine(path, "Start.som");
        }
        //if the file doesn't exist, throw an exception
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File not found", path);
        }
        //load the file
        fileContent = File.ReadAllText(path);
        CleanFile();
    }

    public void CleanFile()
    {
        // Remove all comments 
        // Valid Comment: # This is a comment
        fileContent = Regex.Replace(fileContent, @"#.*", "");
        //remove empty lines
        fileContent = Regex.Replace(fileContent, @"^\s*$\n", "", RegexOptions.Multiline);
    }

    public string[] GetLines()
    {
        return fileContent.Split("\n");
    }
}