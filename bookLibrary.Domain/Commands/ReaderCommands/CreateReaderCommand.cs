namespace bookLibrary.Domain.Commands.ReaderCommands
{
    public class CreateReaderCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}