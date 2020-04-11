using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.BookCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bookLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookHandler _bookHandler;
        private readonly IBookRepository _bookRepository;

        public BookController(BookHandler bookHandler)
        {
            _bookHandler = bookHandler;
        }

        [HttpPost]
        [Route("")]
        public async Task<IResultCommand> Post([FromBody]CreateBookCommand command)
        {
            return await _bookHandler.Handler(command);
        }

        [HttpPut]
        [Route("")]
        public async Task<IResultCommand> Put([FromBody]UpdateBookCommand command)
        {
            return await _bookHandler.Handler(command);
        }

        [HttpGet]
        [Route("by-author/{id:Guid}")]
        public async Task<IResultCommand> GetByAuthor(Guid id)
        {
            IEnumerable<Book> books = await _bookRepository.GetBookByAuthor(id);

            return new ResultCommand { Message = "", Success = true, Data = books };
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IResultCommand> Delete(Guid id)
        {
            await _bookRepository.Delete(id);

            return new ResultCommand { Message = "Livro excluído com sucesso!", Success = true, Data = null };
        }
    }
}