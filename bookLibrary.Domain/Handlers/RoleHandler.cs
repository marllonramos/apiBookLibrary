using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Commands.RolesCommands;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Handlers
{
    public class RoleHandler : Notifiable, IHandler<CreateRoleCommand>, IHandler<UpdatePriorityRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;
        public RoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IResultCommand> Handler(CreateRoleCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            Role role = new Role(command.Name, command.Priority);

            await _roleRepository.CreateRole(role);

            return new ResultCommand { Message = "Perfil cadastrado com sucesso!", Success = true, Data = role };
        }

        public async Task<IResultCommand> Handler(UpdatePriorityRoleCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new ResultCommand { Message = "Ops! Deu erro.", Success = false, Data = command.Notifications };

            Role role = await _roleRepository.GetRole(command.Id);

            role.UpdatePriority(command.Priority);

            await _roleRepository.UpdateRole(role);

            return new ResultCommand { Message = "Prioridade do Perfil atualizada com sucesso!", Success = true, Data = role };
        }
    }
}