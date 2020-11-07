using System;
using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Shared;
using Flunt.Validations;

namespace bookLibrary.Domain.Entities
{
    public class Exemplary : Entity
    {
        public Guid IdReader { get; private set; }
        public Reader Reader { get; private set; }
        public Guid IdBook { get; private set; }
        public Book Book { get; private set; }
        public EStatusExemplary Status { get; private set; }
        public DateTime? StartDateReading { get; private set; }
        public DateTime? EndDateReading { get; private set; }
        public DateTime? LastDateParalisation { get; private set; }
        public int Paralisation { get; private set; }

        public Exemplary(Guid idBook, Guid idReader)
        {
            IdReader = idReader;
            IdBook = idBook;
            Reader = null;
            Book = null;
            Status = EStatusExemplary.QueroComprar;
            StartDateReading = null;
            EndDateReading = null;
            LastDateParalisation = null;
            Paralisation = 0;
        }


        public void PutBook(Book book)
        {
            Book = book;
            AddNotifications(Book);
        }

        public void PutReader(Reader reader)
        {
            Reader = reader;
            AddNotifications(Reader);
        }

        public void PutStatus(EStatusExemplary status) => Status = status;

        public void PutStartDateReading(DateTime? startDate) => StartDateReading = startDate;

        public void PutEndDateReading(DateTime? endDate) => EndDateReading = endDate;

        public void PutLastDateParalisation(DateTime? paralisationDate) => LastDateParalisation = paralisationDate;

        public void PutParalisation(int paralisation) => Paralisation = paralisation;


        public void StartReading()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNull(EndDateReading, "EndDateReading", "Não se pode iniciar uma leitura quando a data fim já foi informada.")
            );

            if (Invalid)
                return;

            StartDateReading = DateTime.Now;
            Status = EStatusExemplary.Lendo;
        }

        public void FinishReading()
        {
            DateTime? finishDate = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(StartDateReading, "StartDateReading", "Para finalizar uma leitura, é preciso iniciá-la.")
            );

            if (Invalid)
                return;

            EndDateReading = finishDate;
            Status = EStatusExemplary.Lido;
        }

        public void PauseReading()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(StartDateReading, "StartDateReading", "A leitura não pode ser paralisada, pois nem iniciada foi.")
                .IsNull(EndDateReading, "EndDateReading", "A leitura não pode ser paralisada, pois o livro já foi lido.")
            );

            if (Invalid)
                return;

            LastDateParalisation = DateTime.Now;
            Status = EStatusExemplary.LeituraPausada;
            Paralisation += 1;
        }

        public void RestartReading()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreEquals(Status, EStatusExemplary.LeituraPausada, "Status", "Sua leitura não está pausada para que possa ser reiniciada.")
            );

            if (Invalid)
                return;

            Status = EStatusExemplary.Lendo;
            StartDateReading = DateTime.Now;
        }

        public void PutInReadingQueue()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreEquals(Status, EStatusExemplary.QueroComprar, "Status", "Sua leitura não pode ser colocada na fila de leitura, pois não está no estado de 'Quero comprar'.")
            );

            if (Invalid)
                return;

            Status = EStatusExemplary.FilaDeLeitura;
        }

        public void FillExemplaryId(Guid id)
        {
            Id = id;
        }

    }
}