using System;
using System.Linq;
using AutoMapper;
using EKadry.Application.Services.Contracts.ContractDetail;
using EKadry.Application.Services.Contracts.ContractList;
using EKadry.Application.Services.JobPositions.JobPositionList;
using EKadry.Application.Services.Operators.OperatorAuthentication;
using EKadry.Application.Services.Operators.OperatorDetail;
using EKadry.Application.Services.Operators.OperatorList;
using EKadry.Application.Services.Periods.PeriodList;
using EKadry.Application.Services.Pkzp.PkzpAccounting;
using EKadry.Application.Services.Pkzp.PkzpPositionList;
using EKadry.Application.Services.Pkzp.PkzpSchedule;
using EKadry.Application.Services.Pkzp.PkzpSummary;
using EKadry.Application.Services.Workers.WorkerList;
using EKadry.Application.Services.Workers.WorkerSearch;
using EKadry.Domain;
using EKadry.Domain.Contracts;
using EKadry.Domain.Contracts.JobPosition;
using EKadry.Domain.Operators;
using EKadry.Domain.Pagination;
using EKadry.Domain.Pkzp;
using EKadry.Domain.Pkzp.Period;
using EKadry.Domain.Pkzp.Position;
using EKadry.Domain.Pkzp.Schedule;
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

            CreateMap<JobPosition, JobPositionListDto>();
            CreateMap<Period, PeriodListDto>();

            CreateMap<Pkzp, PkzpSummaryDto>()
                .ForMember(dest => dest.PkzpType, opt => opt.MapFrom(src => EnumHelper<PkzpType>.GetMap(src.PkzpType)))
                .ForMember(dest => dest.Repayment, opt
                    => opt.MapFrom(src
                        => src.PkzpPosition.PkzpSchedules
                            .Where(x => x.IsClosed)
                            .Sum(x => x.Price)));
            CreateMap<PkzpPosition, PkzpPositionListDto>()
                .ForMember(dest => dest.PkzpPositionType, opt => opt.MapFrom(src => EnumHelper<PkzpPositionType>.GetMap(src.PkzpPositionType)));
            CreateMap<Worker, PkzpAccountingDto>();
            CreateMap<PkzpPosition, PkzpAccountingPkzpPositionDto>();
            CreateMap<PkzpSchedule, PkzpAccountingPkzpScheduleDto>();
            
            CreateMap<PkzpSchedule, PkzpScheduleDto>();

            CreateMap<Operator, OperatorListDto>();
            CreateMap<Operator, OperatorDetailDto>();
            CreateMap<Operator, OperatorAuthorizedDto>();
            CreateMap<Worker, ContractWorkerDetailDto>();
            CreateMap<Guid, Operator>();

            CreateMap<Worker, WorkerListDto>();
            CreateMap<Worker, WorkerSearchDto>();
            CreateMap<Worker, WorkerDetailDto>()
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => EnumHelper<DocumentType>.GetMap(src.DocumentType)))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => EnumHelper<Gender>.GetMap(src.Gender)));
            CreateMap<Guid, Worker>();
        }
    }
}