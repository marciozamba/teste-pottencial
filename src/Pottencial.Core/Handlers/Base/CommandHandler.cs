using Flunt.Notifications;
using MediatR;
using Pottencial.Core.Interfaces.UoW;
using Pottencial.Core.Model.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pottencial.Core.Handlers.Base
{
    public abstract class CommandHandler<TCommand, TResponse> : Notifiable, IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);

        public IList<CommandResultErro> ValidationErrors
        {
            get
            {
                return Notifications
                        .Select(x => new CommandResultErro(x.Property, x.Message))
                        .ToList();
            }
        }

        public async Task<bool> Commit()
        {
            if (Invalid)
                return false;

            if (await _unitOfWork.Comitar())
                return true;

            AddNotification("Commit", "Houve um problema ao salvar as informações.");

            return false;
        }
    }
}

