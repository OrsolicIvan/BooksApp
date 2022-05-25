using AutoMapper;
using Books.Models;

namespace Books.Dto
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
            {
            CreateMap();
}
    private void CreateMap()
    {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<Customer, GetCustomerDto>().ReverseMap();
            
        }

    }
}
