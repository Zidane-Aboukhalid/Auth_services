﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Users.Queries;

public record CheckVerificationEmail(string	Email):IRequest<bool>;