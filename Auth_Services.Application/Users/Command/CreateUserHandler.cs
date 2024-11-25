using AutoMapper;
using MediatR;
using Auth_Services.Domain.InterfacesServices;
using Auth_Services.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Users.Command
{
	public class CreateUserHandler : IRequestHandler<CreateUser, AuthModel>
	{
		private readonly IAuthServices authServices;
		private readonly IMapper mapper;

		public CreateUserHandler(IAuthServices authServices,IMapper mapper)
        {
			this.authServices = authServices;
			this.mapper = mapper;
		}
        public async Task<AuthModel> Handle(CreateUser request, CancellationToken cancellationToken)
		{
			var RegesterModel = mapper.Map<ResgisterModel>(request);
			var result = await	authServices.RegisterAsync(RegesterModel);
			return  result;
		}
	}
}
