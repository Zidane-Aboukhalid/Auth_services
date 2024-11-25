using System.ComponentModel.DataAnnotations;


namespace Auth_Services.Domain.models
{
	public class RolesToUserModel
	{
		[Required]
        public string Id{ get; set; }
		[Required]
		public string Role { get; set; }
    }
}
