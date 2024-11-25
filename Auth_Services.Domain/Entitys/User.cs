using Microsoft.AspNetCore.Identity;


namespace Auth_Services.Domain.Entitys
{
	public class User : IdentityUser
	{
        public string FullName { get; set; }
    }
}
