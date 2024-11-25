using MediatR;
using Auth_Services.Domain.models;

namespace Auth_Services.Application.Users.Queries;

public record loginUser(string Email ,String Password):IRequest<AuthModel>;
