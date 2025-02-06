using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos;
using Data.Data;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Core.Validators
{
    public class SparePartValidator: AbstractValidator<CreateSparePartDto>
    {
        public SparePartValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(120);
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Category is required");
            RuleFor(x => x.ProviderId).GreaterThan(0).WithMessage("Provider is required");
            RuleFor(x => x.ProducerId).GreaterThan(0).WithMessage("Producer is required");
            RuleFor(x => x.Description).MinimumLength(500);
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.PartNumber).MaximumLength(15);
            RuleFor(x => x.ImageUrl)
               .Must(uri => ValidateUri(uri))
               .WithMessage("The ImageUrl must be a valid URI or null/empty.");
        }
        public bool ValidateUri(string? uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
