

namespace Auth_Services.Domain.models
{
	public class VerificationEmailModel
	{
        public string user_id { get; set; }
        public string code { get; set; }
    }
}
