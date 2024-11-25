using AutoMapper;
using Auth_Services.Application.Roles.Command;
using Auth_Services.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Services.Application.Roles.Mapping;

public class RoleToUserMapping:Profile
{
    public RoleToUserMapping()
    {
        CreateMap<AddRoleToUser, RolesToUserModel>()
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(des => des.Role, opt => opt.MapFrom(src => src.RoleName));
			
    }
}
