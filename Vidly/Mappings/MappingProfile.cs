using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}
