using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.BookCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Enums;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Handlers
{
    public class BookHandler : Notifiable, IHandler<CreateBookCommand>, IHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublishingCompanyRepository _publishingCompanyRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReaderRepository _readerRepository;

        public BookHandler(IBookRepository bookRepository, IPublishingCompanyRepository publishingCompanyRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository, IReaderRepository readerRepository)
        {
            _bookRepository = bookRepository;
            _publishingCompanyRepository = publishingCompanyRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _readerRepository = readerRepository;
        }

        public async Task<IResultCommand> Handler(CreateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            PublishingCompany company = await _publishingCompanyRepository.GetById(command.PublishingCompanyId);
            Author author = await _authorRepository.GetById(command.AuthorId);
            Category category = await _categoryRepository.GetById(command.CategoryId);
            Reader reader = await _readerRepository.GetReader(command.ReaderId);

            Book book = new Book(command.Title, command.Description, company, author, category);

            // Caso tiv�ssemos regras de neg�cio na entidade BOOK, ter�amos a valida��o l� e aqui 
            // pegar�amos as notifica��es e atribuir�amos ao Handler
            //AddNotifications(book.Notifications);
            //if (Invalid)
            //    return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = Notifications };

            await _bookRepository.Create(book);

            return new ResultCommand { Message = "Livro cadastrado com sucesso!", Success = true, Data = book };
        }

        public async Task<IResultCommand> Handler(UpdateBookCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            PublishingCompany company = await _publishingCompanyRepository.GetById(command.PublishingCompanyId);
            Author author = await _authorRepository.GetById(command.AuthorId);
            Category category = await _categoryRepository.GetById(command.CategoryId);
            Book book = await _bookRepository.GetBook(command.Id);

            book.UpdateTitle(command.Title);
            book.UpdateDescription(command.Description);
            book.UpdateStatus((StatusBook)command.Status);
            book.UpdateAuthor(author);
            book.UpdatePublishingCompany(company);
            book.UpdateCategory(category);

            // Caso tiv�ssemos regras de neg�cio na entidade BOOK, ter�amos a valida��o l� e aqui 
            // pegar�amos as notifica��es e atribuir�amos ao Handler
            //AddNotifications(book.Notification);
            //if (Invalid)
            //    return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = Notifications };

            await _bookRepository.Update(book);

            return new ResultCommand { Message = "Livro atualizado com sucesso!", Success = true, Data = book };
        }
    }
}