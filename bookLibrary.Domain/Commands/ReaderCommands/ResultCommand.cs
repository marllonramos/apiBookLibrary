namespace bookLibrary.Domain.Commands.ReaderCommands
{
    public class ResultCommand : IResultCommand
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}