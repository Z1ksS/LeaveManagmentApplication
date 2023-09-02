﻿using AutoMapper;
using LeaveManagmentClean.Application.Contracts.Persistence;
using LeaveManagmentClean.Application.Features.LeaveType.Commands.CreateLeaveType;
using MediatR;

namespace LeaveManagmentClean.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            await _leaveTypeRepository.UpdateAsync(leaveTypeToCreate);

            return Unit.Value;
        }
    }
}