using AutoMapper;
using ShoppingComplex.Domain.DTOs;
using ShoppingComplex.Domain.Entities;

namespace ShoppingComplex.Domain.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<StoreDto, Store>().ReverseMap();
            CreateMap<LeaseAgreementDto, LeaseAgreement>().ReverseMap();
            CreateMap<LeasePaymentDto, LeasePayment>().ReverseMap();
        }
    }
}
