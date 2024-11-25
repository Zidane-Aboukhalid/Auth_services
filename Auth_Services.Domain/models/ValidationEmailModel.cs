using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Domain.models;

public class ValidationEmailModel
{
	public string id { get; set; }
	public string code { get; set; }
}
