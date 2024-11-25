using AutoMapper;
using MediatR;
using Auth_Services.Domain.InterfacesServices;
using Auth_Services.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Roles.Command;

public class AddRoleToUserHandler : IRequestHandler<AddRoleToUser, string>
{
	private readonly IAuthServices authServices;
	private readonly IMapper mapper;

	public AddRoleToUserHandler(IAuthServices authServices , IMapper mapper)
    {
		this.authServices = authServices;
		this.mapper = mapper;
	}
    public async Task<string> Handle(AddRoleToUser request, CancellationToken cancellationToken)
	{
		var userRole = mapper.Map<RolesToUserModel>(request);
		var res= await authServices.AddRolesToUser(userRole);
		return res;
	}
}
