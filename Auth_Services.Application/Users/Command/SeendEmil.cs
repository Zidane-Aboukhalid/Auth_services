using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Users.Command;

public record SeendEmil(string Email,string body,string subject):IRequest<bool>;

