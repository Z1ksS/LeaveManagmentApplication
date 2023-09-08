

using FluentValidation.Results;

namespace LeaveManagmentClean.Application.Exceptions
{
    public class BadRequest : Exception
    {
        public List<string> ValidationErrors { get; set; }
        public BadRequest(string message) : base(message)
        {

        }
        
        public BadRequest(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = new();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
    }
}