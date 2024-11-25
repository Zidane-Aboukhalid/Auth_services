using MediatR;
using Auth_Services.Domain.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Users.Queries
{
	public class GetCountUsersHandler:IRequestHandler<GetCountUsers,int>
	{
		private readonly IAuthServices authServices;

		public GetCountUsersHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}

		public async Task<int> Handle(GetCountUsers request, CancellationToken cancellationToken)
		{
			return await authServices.GetCountUsersAsync();
		}
	}
}
