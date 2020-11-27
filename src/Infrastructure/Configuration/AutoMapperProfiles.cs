using System;
using AutoMapper;
using EKadry.Application.Services.Operators.OperatorAuthentication;
using EKadry.Application.Services.Operators.OperatorDetail;
using EKadry.Application.Services.Operators.OperatorList;
using EKadry.Domain;
using EKadry.Domain.Operators;
using EKadry.Domain.Pagination;

namespace EKadry.Infrastructure.Configuration
{
    internal class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TypedIdValueBase, Guid>().ConvertUsing(s => s.Value);
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));
            
            CreateMap<Operator, OperatorListDto>();
            CreateMap<Operator, OperatorDetailDto>();
            CreateMap<Operator, OperatorAuthorizedDto>();
            CreateMap<OperatorId, Operator>();
        }
    }
}