using MediatR;
using Auth_Services.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Users.Command;

public record CreateUser(string fullname , string username , string email , string password):IRequest<AuthModel>;

