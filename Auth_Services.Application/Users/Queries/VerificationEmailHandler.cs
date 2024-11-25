using MediatR;
using Auth_Services.Domain.InterfacesServices;
using Auth_Services.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Users.Queries
{
	public class VerificationEmailHandler : IRequestHandler<VerificationEmail, VerificationEmailModel>
	{
		private readonly IAuthServices authServices;

		public VerificationEmailHandler(IAuthServices authServices)
        {
			this.authServices = authServices;
		}
        public async Task<VerificationEmailModel> Handle(VerificationEmail request, CancellationToken cancellationToken)
		{
			return await authServices.GenerateEmailConfirmationTokenAsync(request.Email);
		}
	}
}
