using bookLibrary.Domain.Commands;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<IResultCommand> Handler(T command);
    }
}