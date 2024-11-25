using MediatR;
using Auth_Services.Domain.models;

namespace Auth_Services.Application.Users.Command
{
	public  record  CreateUserByGoogle(string fullname, string username, string email) :IRequest<AuthModel>;
}
