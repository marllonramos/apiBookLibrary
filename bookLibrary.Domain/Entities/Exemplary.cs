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
            Status = StatusExemplary.QueroComprar;
            StartDateReading = null;
            EndDateReading = null;
            LastDateParalisation = null;
            Paralisation = 0;

            AddNotifications(book, reader);
        }

        public void StartReading()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNullOrNullable(EndDateReading, "EndDateReading", "Não se pode iniciar uma leitura quando a data fim já foi informada.")
            );

            if (Invalid)
                return;

            StartDateReading = DateTime.Now;
            Status = StatusExemplary.Lendo;
        }

        public void FinishReading()
        {
            var finishDate = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(StartDateReading, "StartDateReading", "Para finalizar uma leitura, é preciso iniciá-la.")
                .IsGreaterOrEqualsThan(finishDate, StartDateReading.Value, "EndDateReading", "Data fim da leitura não pode ser menor que a data de início da leitura.")
            );

            if (Invalid)
                return;

            EndDateReading = finishDate;
            Status = StatusExemplary.Lido;
        }

        public void UpdateEndDateReading()
        {
            var endDate = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(endDate, StartDateReading.Value, "EndDateReading", "Data fim da leitura não pode ser menor que a data de início da leitura.")
            );

            if (Invalid)
                return;

            EndDateReading = endDate;
            Status = StatusExemplary.Lido;
        }

        public void UpdateStartDateReading()
        {
            var startDate = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(startDate, EndDateReading.Value, "StartDateReading", "Data início da leitura não pode ser maior que a data fim da leitura.")
            );

            if (Invalid)
                return;

            StartDateReading = startDate;
            Status = StatusExemplary.Lendo;
        }

        public void AddParalisation()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(StartDateReading.Value.ToString(), "StartDateReading", "A leitura não pode ser paralisada, pois nem iniciada foi.")
                .IsNullOrNullable(EndDateReading, "EndDateReading", "A leitura não pode ser paralisada, pois o livro já foi lido.")
            );

            if (Invalid)
                return;

            LastDateParalisation = DateTime.Now;
            Status = StatusExemplary.LeituraPausada;
            Paralisation += 1;
        }

        // public void AlterStatus(StatusExemplary status)
        // {
        //     AddNotifications(new Contract()
        //         .Requires()
        //         .IsTrue()
        //         .IsNullOrNullable(StartDateReading, "StartDateReading", "")
        //     );
        //     Status = status;
        // }

        // private bool IsStatusReading
    }
}