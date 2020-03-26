namespace bookLibrary.Domain.Commands.BookCommands
{
    public class CreateBookCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int PublishingCompanyId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}