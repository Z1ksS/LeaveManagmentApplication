﻿using FluentValidation;
using LeaveManagmentClean.Application.Contracts.Persistence;

namespace LeaveManagmentClean.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");
            
            RuleFor(p => p.DefaultDays) 
                .LessThan(100).WithMessage("{PropertyName} cannot exceed 100") 
                .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");
            
            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave type already exists");
        }

        private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}