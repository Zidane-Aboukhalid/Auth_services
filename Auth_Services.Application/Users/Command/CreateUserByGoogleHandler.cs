﻿

using AutoMapper;
using MediatR;
using Auth_Services.Domain.InterfacesServices;
using Auth_Services.Domain.models;

namespace Auth_Services.Application.Users.Command
{
	public class CreateUserByGoogleHandler : IRequestHandler<CreateUserByGoogle, AuthModel>
	{
		private readonly IAuthServices authServices;
		private readonly IMapper mapper;

		public CreateUserByGoogleHandler(IAuthServices authServices , IMapper mapper)
        {
			this.authServices = authServices;
			this.mapper = mapper;
		}
        public async Task<AuthModel> Handle(CreateUserByGoogle request, CancellationToken cancellationToken)
		{
			var userByGoogle = mapper.Map<ResgisterGoogleModel>(request);
			var res = await authServices.RegisterGoogleAsync(userByGoogle);
			return res;
		}
	}
}