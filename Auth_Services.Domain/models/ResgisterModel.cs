using System.ComponentModel.DataAnnotations;


namespace Auth_Services.Domain.models;

public class ResgisterModel
{
    [Required,MaxLength(100)]
    public string fullName { get; set; }
	[Required, MaxLength(50)]
	public string Username { get; set; }
	[Required, MaxLength(120)]
	public string Email { get; set; }
	[Required, MaxLength(256)]
	public string Password { get; set; }
}
