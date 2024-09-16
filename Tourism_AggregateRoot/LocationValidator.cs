using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism_DTO;

namespace Tourism_AggregateRoot
{
    public class LocationValidator : AbstractValidator<LocationDTO>
    {
        public LocationValidator() 
        {
            RuleFor(u => u.LocationName)
                .NotEmpty().WithMessage("Location Number is Required.");

            RuleFor(u => u.LocationAddress)
                .NotEmpty()
                .Length(1, 50).WithMessage("Location Address must be between 1 and 50 characters.");

            RuleFor(u => u.LocationCity)
                .NotEmpty().Length(1, 50).WithMessage("Location city must be between 1 and 50 characters.");

            RuleFor(u => u.Capacity)
                .NotEmpty().GreaterThan(0).WithMessage("Enter the capacity of the location.");
                

            RuleFor(u => u.Cost)
                .GreaterThan(0).WithMessage("Enter the Cost for Per Person.");

           
        }
    }
}
