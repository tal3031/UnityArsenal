namespace UnityArsenal.Core.Commands
{
    public delegate void CommandEvent(ICommand command);

    public interface ICommand
    {
        void Execute();
    }
}
