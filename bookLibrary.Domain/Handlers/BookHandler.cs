using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.BookCommands;
using bookLibrary.Domain.Entities;
using Flunt.Notifications;

namespace bookLibrary.Domain.Handlers
{
    public class BookHandler : Notifiable, IHandler<CreateBookCommand>, IHandler<UpdateBookCommand>
    {
        public BookHandler()
        {
        }

        public IResultCommand Handler(CreateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            //TODO: realizar consultas e atribuir os valores
            // PublishingCompany company = repository.Get(command.PublishingCompanyId);
            // Author author = repository.Get(command.AuthorId);
            // Category category = repository.Get(command.CategoryId);

            // Book book = new Book(command.Title, command.Description, company, author, category);

            // if (book.Invalid)
            //     return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = book.Notifications };

            // repository.Save(book);

            return new ResultCommand { Message = "Livro cadastrado com sucesso!", Success = true, Data = command };
        }

        public IResultCommand Handler(UpdateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            //TODO: realizar consultas e atribuir os valores
            // PublishingCompany company = repository.Get(command.PublishingCompanyId);
            // Author author = repository.Get(command.AuthorId);
            // Category category = repository.Get(command.CategoryId);
            // Book book = repository.Get(command.Id);
            // book.Title = "";
            // book.Description = "";
            // book.Status = command.Status;
            // book.Author = author;
            // book.PublishingCompany = company;
            // book.Category = category;


            // if(book.Invalid)
            //     return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = book.Notifications };

            // repository.Save(book);

            return new ResultCommand { Message = "Livro atualizado com sucesso!", Success = true, Data = command };
        }
    }
}