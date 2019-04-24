using AutoMapper;
using Razorpages.Model;

namespace Razorpages.Mapper
{
	public class WizzardProfile : Profile
	{
		public WizzardProfile()
		{
			CreateMap<WizzardData, Pages.IndexModel>().ReverseMap();
			CreateMap<WizzardData, Pages.SecondPageModel>().ReverseMap();
			CreateMap<WizzardData, Pages.ThirdPageModel>().ReverseMap();
		}
	}
}
