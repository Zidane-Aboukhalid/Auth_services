using System.ComponentModel.DataAnnotations;


namespace Auth_Services.Domain.models;

public class LoginModel
{
    [Required]
    public string Email { get; set; }
	[Required]
	public string Password { get; set; }
}
