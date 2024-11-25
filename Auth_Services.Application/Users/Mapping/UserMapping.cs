using AutoMapper;
using Auth_Services.Application.Users.Command;
using Auth_Services.Application.Users.Queries;
using Auth_Services.Domain.models;

namespace Auth_Services.Application.Users.Mapping;

public class UserMapping:Profile
{
    public UserMapping()
    {
        CreateMap<CreateUser, ResgisterModel>()
            .ForMember(des=> des.fullName,opt=> opt.MapFrom(src=>src.fullname))
            .ForMember(des=> des.Username,opt=>opt.MapFrom(src=>src.username))
            .ForMember(des=> des.Email,opt=>opt.MapFrom(src=>src.email))
            .ForMember(des=> des.Password,opt=>opt.MapFrom(src=>src.password))
            .ReverseMap();

		CreateMap<loginUser, LoginModel>()
			.ForMember(des => des.Email, opt => opt.MapFrom<string>(src => src.Email))
			.ForMember(des => des.Password, opt => opt.MapFrom(src => src.Password))
			.ReverseMap();

		CreateMap<CreateUserByGoogle, ResgisterGoogleModel>()
			.ForMember(des => des.fullName, opt => opt.MapFrom(src => src.fullname))
			.ForMember(des => des.Username, opt => opt.MapFrom(src => src.username))
			.ForMember(des => des.Email, opt => opt.MapFrom(src => src.email))
			.ReverseMap();


		CreateMap<loginUserWithGoogle, LoginGoogleModel>()
			.ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
			.ForMember(des => des.provaiderName, opt => opt.MapFrom(src => src.LoginProvider))
			.ReverseMap();



		CreateMap<ValidationEmail, ValidationEmailModel>()
			.ForMember(des => des.id, opt => opt.MapFrom(src => src.id))
			.ForMember(des => des.code, opt => opt.MapFrom(src => src.code))
			.ReverseMap();
	}
}
