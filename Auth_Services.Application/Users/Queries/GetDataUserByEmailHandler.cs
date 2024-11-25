using MediatR;
using Auth_Services.Domain.InterfacesServices;
using Auth_Services.Domain.models;

namespace Auth_Services.Application.Users.Queries
{
	public class GetDataUserByEmailHandler:IRequestHandler<GetDataUserByEmail, userData>
	{
		private readonly IAuthServices authServices;

		public GetDataUserByEmailHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}

		public async Task<userData> Handle(GetDataUserByEmail request, CancellationToken cancellationToken)
		{
			var userdata = await authServices.GetDataUserByEmailAsync(request.email);
			return userdata;
		}
	}
}
