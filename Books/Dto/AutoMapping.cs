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
            CreateMap<AddAuthorDto, Author>().ReverseMap();
            CreateMap<GetAuthorDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();  
        }

    }
}
