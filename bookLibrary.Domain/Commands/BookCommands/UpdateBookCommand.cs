using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace bookLibrary.Domain.Commands.BookCommands
{
    public class UpdateBookCommand : Notifiable, IValidatable, ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int PublishingCompanyId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Title, "Title", "Informe o título do livro.")
                .HasMinLen(Title, 3, "Title", "Informe um mínimo de 3 caracteres e um máximo de 50 para o livro.")
                .HasMaxLen(Title, 50, "Title", "Informe um mínimo de 3 caracteres e um máximo de 50 para o livro.")
                .AreNotEquals(Status, 0, "Status", "Informe o status do livro.")
                .AreNotEquals(PublishingCompanyId, 0, "PublishingCompanyId", "Informe uma editora.")
                .AreNotEquals(AuthorId, 0, "AuthorId", "Informe um autor.")
                .AreNotEquals(CategoryId, 0, "CategoryId", "Informe uma categoria.")
            );
        }
    }
}
