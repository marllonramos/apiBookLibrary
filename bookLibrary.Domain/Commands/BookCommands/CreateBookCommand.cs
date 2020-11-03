using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace bookLibrary.Domain.Commands.BookCommands
{
    public class CreateBookCommand : Notifiable, IValidatable, ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid PublishingCompanyId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Title, "Title", "Informe o título.")
                .HasMinLen(Title, 3, "Title", "Informe um m�nimo de 3 caracteres e um m�ximo de 50 para o título.")
                .HasMaxLen(Title, 50, "Title", "Informe um m�nimo de 3 caracteres e um m�ximo de 50 para o título.")
                .HasMaxLen(Description, 250, "Description", "Informe no m�ximo 250 caracteres para a descri��o.")
                .IsNotNullOrEmpty(PublishingCompanyId.ToString(), "PublishingCompanyId", "Informe uma editora.")
                .IsNotNullOrEmpty(AuthorId.ToString(), "AuthorId", "Informe um autor.")
                .IsNotNullOrEmpty(CategoryId.ToString(), "CategoryId", "Informe uma categoria.")
            );
        }
    }
}