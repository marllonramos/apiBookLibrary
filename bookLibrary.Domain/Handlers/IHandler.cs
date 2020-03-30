using bookLibrary.Domain.Commands;

namespace bookLibrary.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        IResultCommand Handler(ICommand T);
    }
}