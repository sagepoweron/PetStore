using FluentValidation;
using PetStore.Products;

namespace PetStore.Validators
{
	public class DogLeashValidator : AbstractValidator<DogLeash>
	{
		public DogLeashValidator()
		{
			RuleFor(dogleash => dogleash.Name).NotEmpty();
			RuleFor(dogleash => dogleash.Price).GreaterThanOrEqualTo(0);
			RuleFor(dogleash => dogleash.Quantity).GreaterThanOrEqualTo(0);
			RuleFor(dogleash => dogleash.Description).MinimumLength(10).When(dogleash => !string.IsNullOrEmpty(dogleash.Description));
		}
	}
}
