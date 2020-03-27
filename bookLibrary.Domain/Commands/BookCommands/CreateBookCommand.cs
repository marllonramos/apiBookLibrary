using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.BookCommands
{
    public class CreateBookCommand : Notifiable, IValidatable, ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishingCompanyId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Title, "Title", "Informe o nome do leitor.")
                .HasMinLen(Title, 3, "Title", "Informe um m�nimo de 3 caracteres e um m�ximo de 50 para o livro.")
                .HasMaxLen(Title, 50, "Title", "Informe um m�nimo de 3 caracteres e um m�ximo de 50 para o livro.")
                .AreNotEquals(PublishingCompanyId, 0, "PublishingCompanyId", "Informe uma editora.")
                .AreNotEquals(AuthorId, 0, "AuthorId", "Informe um autor.")
                .AreNotEquals(CategoryId, 0, "CategoryId", "Informe uma categoria.")
            );
        }
    }
}