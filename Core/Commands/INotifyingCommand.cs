namespace UnityArsenal.Core.Commands
{
    public interface INotifyingCommand : ICommand
    {
        event CommandEvent ExecutionComplete;
    }
}
