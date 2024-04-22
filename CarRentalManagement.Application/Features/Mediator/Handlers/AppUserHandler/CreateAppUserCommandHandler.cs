using CarRentalManagement.Application.Enums;
using CarRentalManagement.Application.Features.Mediator.Commands.AppUserCommands;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.AppUserHandler
{
	public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
	{
		private readonly IRepository<AppUser> _appUserRepository;

		public CreateAppUserCommandHandler(IRepository<AppUser> appUserRepository)
		{
			_appUserRepository = appUserRepository;
		}

		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			await _appUserRepository.CreateAsync(new AppUser
			{
				Username = request.Username,
				Password = request.Password,
				Name = request.Name,
				Surname = request.Surname,
				Email = request.Email,
				AppRoleId = (int)RoleTypes.Member
			});
		}
	}
}
