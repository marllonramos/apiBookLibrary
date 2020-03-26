using System;

namespace bookLibrary.Domain.Commands.ReaderCommands
{
    public class UpdateReaderCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}