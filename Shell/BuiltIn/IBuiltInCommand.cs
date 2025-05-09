namespace Shell.BuiltIn
{
    public interface IBuiltInCommand
    {
        bool CanHandle(string name);
        void Execute(string[] args);
    }
}