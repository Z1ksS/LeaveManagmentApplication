using AutoMapper;
using LeaveManagmentClean.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using LeaveManagmentClean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using LeaveManagmentClean.Domain;

namespace LeaveManagmentClean.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}