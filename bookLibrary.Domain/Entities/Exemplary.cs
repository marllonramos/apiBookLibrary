using System;
using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Shared;
using Flunt.Validations;

namespace bookLibrary.Domain.Entities
{
    public class Exemplary : Entity
    {
        public Book Book { get; private set; }
        public Reader Reader { get; private set; }
        public StatusExemplary Status { get; private set; }
        public DateTime? StartDateReading { get; private set; }
        public DateTime? EndDateReading { get; private set; }
        public DateTime? LastDateParalisation { get; private set; }
        public int Paralisation { get; private set; }

        public Exemplary(Book book, Reader reader)
        {
            Book = book;
            Reader = reader;
            Status = StatusExemplary.FilaDeLeitura;
            StartDateReading = null;
            EndDateReading = null;
            LastDateParalisation = null;
            Paralisation = 0;

            AddNotifications(book, reader);
        }

        public void UpdateEndDateReading(DateTime endDate)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(endDate, StartDateReading.Value, "EndDateReading", "Data fim da leitura não pode ser menor que a data de início da leitura.")
            );

            if (Invalid)
                return;

            EndDateReading = endDate;
        }

        public void UpdateStartDateReading(DateTime startDate)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(startDate, EndDateReading.Value, "StartDateReading", "Data início da leitura não pode ser maior que a data fim da leitura.")
            );

            if (Invalid)
                return;

            StartDateReading = startDate;
        }

        public void AddParalisation()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(StartDateReading.Value.ToString(), "StartDateReading", "A leitura não pode ser paralisada, pois nem iniciada foi.")
                .IsNullOrEmpty(EndDateReading.Value.ToString(), "EndDateReading", "A leitura não pode ser paralisada, pois o livro já foi lido.")
            );

            if (Invalid)
                return;

            LastDateParalisation = DateTime.Now;
            Paralisation += 1;
        }
    }
}