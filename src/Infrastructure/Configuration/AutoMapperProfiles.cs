using System;
using AutoMapper;
using EKadry.Application.Services.Contracts;
using EKadry.Application.Services.Contracts.ContractDetail;
using EKadry.Application.Services.Contracts.ContractList;
using EKadry.Application.Services.Operators.OperatorAuthentication;
using EKadry.Application.Services.Operators.OperatorDetail;
using EKadry.Application.Services.Operators.OperatorList;
using EKadry.Application.Services.Workers.WorkerList;
using EKadry.Domain;
using EKadry.Domain.Contracts;
using EKadry.Domain.Operators;
using EKadry.Domain.Pagination;
using EKadry.Domain.Workers;
using WorkerDetailDto = EKadry.Application.Services.Workers.WorkerDetail.WorkerDetailDto;
using ContractWorkerDetailDto = EKadry.Application.Services.Contracts.ContractList.WorkerDetailDto;

namespace EKadry.Infrastructure.Configuration
{
    internal class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TypedIdValueBase, Guid>().ConvertUsing(s => s.Value);
            CreateMap<DocumentType, string>().ConvertUsing(s => s.ToString());
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));

            CreateMap<Contract, ContractListDto>();
            CreateMap<Contract, ContractDetailDto>();
            CreateMap<Guid, Contract>();
            
            CreateMap<Operator, OperatorListDto>();
            CreateMap<Operator, OperatorDetailDto>();
            CreateMap<Operator, OperatorAuthorizedDto>();
            CreateMap<Worker, ContractWorkerDetailDto>();
            CreateMap<Guid, Operator>();
            
            CreateMap<Worker, WorkerListDto>();
            CreateMap<Worker, WorkerDetailDto>()
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => EnumHelper<DocumentType>.GetMap(src.DocumentType)))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => EnumHelper<Gender>.GetMap(src.Gender)));
            CreateMap<Guid, Worker>();
        }
    }
}