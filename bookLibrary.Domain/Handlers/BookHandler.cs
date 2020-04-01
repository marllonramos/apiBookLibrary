using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.BookCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;

namespace bookLibrary.Domain.Handlers
{
    public class BookHandler : Notifiable, IHandler<CreateBookCommand>, IHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublishingCompanyRepository _publishingCompanyRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookHandler(IBookRepository bookRepository, IPublishingCompanyRepository publishingCompanyRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _publishingCompanyRepository = publishingCompanyRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }

        public IResultCommand Handler(CreateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            PublishingCompany company = _publishingCompanyRepository.GetById(command.PublishingCompanyId);
            Author author = _authorRepository.GetById(command.AuthorId);
            Category category = _categoryRepository.GetById(command.CategoryId);

            Book book = new Book(command.Title, command.Description, company, author, category);

            // Caso tivéssemos regras de negócio na entidade BOOK, teríamos a validação lá e aqui 
            // pegaríamos as notificações e atribuiríamos ao Handler
            //AddNotifications(book.Notifications);
            //if (Invalid)
            //    return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = Notifications };

            _bookRepository.Create(book);

            return new ResultCommand { Message = "Livro cadastrado com sucesso!", Success = true, Data = book };
        }

        public IResultCommand Handler(UpdateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            PublishingCompany company = _publishingCompanyRepository.GetById(command.PublishingCompanyId);
            Author author = _authorRepository.GetById(command.AuthorId);
            Category category = _categoryRepository.GetById(command.CategoryId);
            Book book = _bookRepository.GetBook(command.Id);

            book.UpdateTitle(command.Title);
            book.UpdateDescription(command.Description);
            book.UpdateStatus((StatusBook)command.Status);
            book.UpdateAuthor(author);
            book.UpdatePublishingCompany(company);
            book.UpdateCategory(category);

            // Caso tivéssemos regras de negócio na entidade BOOK, teríamos a validação lá e aqui 
            // pegaríamos as notificações e atribuiríamos ao Handler
            //AddNotifications(book.Notification);
            //if (Invalid)
            //    return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = Notifications };

            _bookRepository.Update(book);

            return new ResultCommand { Message = "Livro atualizado com sucesso!", Success = true, Data = book };
        }
    }
}