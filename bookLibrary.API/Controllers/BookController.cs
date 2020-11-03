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

        public BookController(BookHandler bookHandler, IBookRepository bookRepository)
        {
            _bookHandler = bookHandler;
            _bookRepository = bookRepository;
        }

        [HttpPost]
        [Route("")]
        public async Task<IResultCommand> Post([FromBody] CreateBookCommand command)
        {
            try
            {
                return await _bookHandler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Erro ao cadastrar Livro.", Success = false, Data = ex.Message };
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<IResultCommand> Put([FromBody] UpdateBookCommand command)
        {
            try
            {
                return await _bookHandler.Handler(command);
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Erro ao atualizar Livro.", Success = false, Data = ex.Message };
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IResultCommand> Delete(Guid id)
        {
            try
            {
                await _bookRepository.Delete(id);
                return new ResultCommand { Message = "Livro excluído com sucesso!", Success = true, Data = null };
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Erro ao excluir Livro.", Success = false, Data = ex.Message };
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IResultCommand> GetBook(Guid id)
        {
            try
            {
                Book book = await _bookRepository.GetBook(id);
                return new ResultCommand { Message = "", Success = true, Data = book };
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Não foi possível consultar o livro desejado.", Success = false, Data = ex.Message };
            }
        }

        [HttpGet]
        [Route("by-author/{id:Guid}")]
        public async Task<IResultCommand> GetByAuthor(Guid id)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.GetBookByAuthor(id);
                return new ResultCommand { Message = "", Success = true, Data = books };
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Erro ao consultar Livro.", Success = false, Data = ex.Message };
            }
        }

        [HttpGet]
        [Route("by-category/{id:Guid}")]
        public async Task<IResultCommand> GetByCategory(Guid id)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.GetBookByCategory(id);
                return new ResultCommand { Message = "", Success = true, Data = books };
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Erro ao consultar Livro.", Success = false, Data = ex.Message };
            }
        }

        [HttpGet]
        [Route("by-publishing/{id:Guid}")]
        public async Task<IResultCommand> GetByPublishing(Guid id)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.GetBookByPublishingCompany(id);
                return new ResultCommand { Message = "", Success = true, Data = books };
            }
            catch (Exception ex)
            {
                return new ResultCommand { Message = "Erro ao consultar Livro.", Success = false, Data = ex.Message };
            }
        }
    }
}