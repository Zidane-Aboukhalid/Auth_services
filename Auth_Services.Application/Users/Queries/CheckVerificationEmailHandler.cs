using MediatR;
using Auth_Services.Domain.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Users.Queries
{
	public class CheckVerificationEmailHandler:IRequestHandler<CheckVerificationEmail,bool>
	{
		private readonly IAuthServices authServices;

		public CheckVerificationEmailHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}

		public async Task<bool> Handle(CheckVerificationEmail request, CancellationToken cancellationToken)
		{
			return await authServices.CheckVerificationEmailDone(request.Email);
		}
	}
}
