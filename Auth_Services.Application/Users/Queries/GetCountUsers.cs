using MediatR;
namespace Auth_Services.Application.Users.Queries;

public record GetCountUsers():IRequest<int>;
