using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.Common.ViewModels;
using WebApp.Model.DatabaseModels;

namespace WebApp.Common.Mapper
{
    public class MappingProfile:Profile
    {
		public MappingProfile()
		{
			var hmac = new HMACSHA256();

			CreateMap<RegisterUser, User>().ReverseMap();
			CreateMap<SignInUser, User>().ReverseMap();
			CreateMap<ProductModel, Product>()
				.ForMember("Name",opt => opt.MapFrom(ud => $"{ud.Name}"))
				.ForMember("Description", opt => opt.MapFrom(ud => $"{ud.Description}")).ReverseMap();

			CreateMap<UserModel, User>()
				.ForMember("Username", opt => opt.MapFrom(ud => ud.Username.ToLower()))
				.ForMember("PasswordHash", opt => opt.MapFrom(ud => hmac.ComputeHash(Encoding.UTF8.GetBytes(ud.Password))))
				.ForMember("PasswordSalt", opt => opt.MapFrom(ud => hmac.Key)).ReverseMap();
		}
	}
}
