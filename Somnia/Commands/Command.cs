namespace Somnia.Commands;

public abstract class Command
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public abstract void Execute(string[] args);
    
    public Command(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    public Command()
    {
        Name = "empty";
        Description = "No description";
    }
}