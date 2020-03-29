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
        public Guid PublishingCompanyId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Id, "Id", "Livro não identificado.")
                .AreNotEquals(Id, 0, "", "Livro não identificado.")
                .IsNotNullOrEmpty(Title, "Title", "Informe o título do livro.")
                .HasMinLen(Title, 3, "Title", "Informe um mínimo de 3 caracteres e um máximo de 50 para o livro.")
                .HasMaxLen(Title, 50, "Title", "Informe um mínimo de 3 caracteres e um máximo de 50 para o livro.")
                .AreNotEquals(Status, 0, "Status", "Informe o status do livro.")
                .HasMaxLen(Description, 250, "Description", "Informe no máximo 250 caracteres para a descrição.")
                .IsNotNullOrEmpty(PublishingCompanyId.ToString(), "PublishingCompanyId", "Informe uma editora.")
                .IsNotNullOrEmpty(AuthorId.ToString(), "AuthorId", "Informe um autor.")
                .IsNotNullOrEmpty(CategoryId.ToString(), "CategoryId", "Informe uma categoria.")
            );
        }
    }
}
