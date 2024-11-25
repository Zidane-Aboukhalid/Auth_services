using MediatR;
using Auth_Services.Domain.InterfacesServices;
using Auth_Services.Domain.models;

namespace Auth_Services.Application.Users.Queries
{
	public class GetDataUserByIdHandler:IRequestHandler<GetDataUserById, userData>
	{
		private readonly IAuthServices authServices;

		public GetDataUserByIdHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}

		public async Task<userData> Handle(GetDataUserById request, CancellationToken cancellationToken)
		{
			var userdata = await authServices.GetDataUserByIdAsync(request.id);
			return userdata;
		}
	}
}
