using System;
using bookLibrary.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace bookLibrary.Domain.Commands.ReaderCommands
{
    public class AddExemplaryCommand : Notifiable, IValidatable, ICommand
    {
        public Guid IdReader { get; set; }
        public Guid IdBook { get; set; }
        public StatusExemplary Status { get; set; }
        public DateTime? DataInicioLeitura { get; set; }
        public DateTime? DataFimLeitura { get; set; }
        public DateTime? DataDaUltimaParalisacao { get; set; }
        public int Paralisacoes { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(IdReader.ToString(), "IdReader", "Leitor não informado.")
                .IsNotNullOrEmpty(IdBook.ToString(), "IdBook", "Livro não informado.")
                .AreEquals(Status.GetType(), GetType().IsEnum, "Status", "Informe o status.")
                .IsNotNull(Paralisacoes, "Paralisacoes", "Quantidade de paralisação não pode ser nulo.")
            );
        }
    }
}