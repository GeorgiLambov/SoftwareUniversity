namespace Estates.Interfaces
{
    public interface IEstateEngine
    {
        string ExecuteCommand(string cmdName, string[] cmdArgs);
    }
}
