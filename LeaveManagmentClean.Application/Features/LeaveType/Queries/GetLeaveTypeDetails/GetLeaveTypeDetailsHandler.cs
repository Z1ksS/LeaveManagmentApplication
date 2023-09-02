using AutoMapper;
using LeaveManagmentClean.Application.Contracts.Persistence;
using LeaveManagmentClean.Application.Exceptions;
using MediatR;

namespace LeaveManagmentClean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            
            if (leaveType is null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            
            var leaveTypeDto = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

            return leaveTypeDto;
        }
    }
}