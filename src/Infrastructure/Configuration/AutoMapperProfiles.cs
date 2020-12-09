using System;
using AutoMapper;
using EKadry.Application.Services.Operators.OperatorAuthentication;
using EKadry.Application.Services.Operators.OperatorDetail;
using EKadry.Application.Services.Operators.OperatorList;
using EKadry.Application.Services.Workers.WorkerDetail;
using EKadry.Application.Services.Workers.WorkerList;
using EKadry.Domain;
using EKadry.Domain.Operators;
using EKadry.Domain.Pagination;
using EKadry.Domain.Workers;

namespace EKadry.Infrastructure.Configuration
{
    internal class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TypedIdValueBase, Guid>().ConvertUsing(s => s.Value);
            CreateMap<DocumentType, string>().ConvertUsing(s => s.ToString());
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));
            
            CreateMap<Operator, OperatorListDto>();
            CreateMap<Operator, OperatorDetailDto>();
            CreateMap<Operator, OperatorAuthorizedDto>();
            CreateMap<OperatorId, Operator>();
            
            CreateMap<Worker, WorkerListDto>();
            CreateMap<Worker, WorkerDetailDto>()
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => EnumHelper<DocumentType>.GetMap(src.DocumentType)))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => EnumHelper<Gender>.GetMap(src.Gender)));
            CreateMap<WorkerId, Worker>();
        }
    }
}