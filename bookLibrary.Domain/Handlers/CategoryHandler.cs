﻿using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.CategoryCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;

namespace bookLibrary.Domain.Handlers
{
    public class CategoryHandler :
        Notifiable,
        IHandler<CreateCategoryCommand>,
        IHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public CategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IResultCommand Handler(CreateCategoryCommand command)
        {
            command.Validate();
            ResultCommand result;
            if (command.Invalid)
            {
                result = new ResultCommand { Message = "Erro ao cadastrar categoria.", Success = false, Data = command.Notifications };
            }
            else
            {
                var category = new Category(command.Name);
                _repository.Create(category);
                result = new ResultCommand { Message = "Sucesso ao cadastrar categoria.", Success = true, Data = category };
            }

            return result;
        }

        public IResultCommand Handler(UpdateCategoryCommand command)
        {
            command.Validate();
            ResultCommand result;
            if (command.Invalid)
            {
                result = new ResultCommand() { Message = "Erro ao atualizar categoria.", Success = false, Data = command.Notifications };
            }
            else
            {
                var category = _repository.GetById(command.Id);
                category.Update(command.Name);
                _repository.Update(category);
                result = new ResultCommand() { Message = "Sucesso ao atualizar categoria.", Success = true, Data = category };
            }

            return result;
        }
    }
}