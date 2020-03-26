using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.ReaderCommands
{
    public class UpdateReaderCommand : Notifiable, IValidatable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Id.ToString(), "Id", "Informe um leitor.")
                .IsNullOrEmpty(Name, "Name", "Informe o nome do leitor.")
                .HasMinLen(Name, 3, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para o leitor.")
                .HasMaxLen(Name, 30, "Name", "Informe um mínimo de 3 caracteres e um máximo de 30 para o leitor.")
                .IsNullOrEmpty(Email, "Email", "Informe o email.")
                .IsEmail(Email, "Email", "Email inválido.")
                .IsNullOrEmpty(Password, "Password", "Informe sua senha.")
                .HasMinLen(Password, 4, "Password", "Informe um mínimo de 4 caracteres e um máximo de 8 para a senha.")
                .HasMaxLen(Password, 8, "Password", "Informe um mínimo de 4 caracteres e um máximo de 8 para a senha.")
            );
        }
    }
}