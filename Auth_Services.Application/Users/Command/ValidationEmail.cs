using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Users.Command;

public record ValidationEmail(string id,string code):IRequest<bool>;
