using FluentValidation;
using PetStore.Data;

namespace PetStore.Validators
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(product => product.Name).NotEmpty();
			RuleFor(product => product.Price).GreaterThanOrEqualTo(0);
			RuleFor(product => product.Quantity).GreaterThanOrEqualTo(0);
			RuleFor(product => product.Description).MinimumLength(10).When(product => !string.IsNullOrEmpty(product.Description));
		}
	}
}
