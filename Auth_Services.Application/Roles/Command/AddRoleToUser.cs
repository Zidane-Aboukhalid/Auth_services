using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Roles.Command;

public record AddRoleToUser(Guid id , string RoleName):IRequest<string>;
