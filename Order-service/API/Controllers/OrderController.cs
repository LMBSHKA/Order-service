using API.Contracts.Orders;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/v1/orders")]
	public class OrderController : ControllerBase
	{
		private readonly IValidator<CreateOrderRequest> _validator;
		public OrderController(IValidator<CreateOrderRequest> validator)
		{
			_validator = validator;
		}

		public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
		{
			var validationResult = await _validator.ValidateAsync(request);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => new
				{
					field = x.PropertyName,
					message = x.ErrorMessage
				}));
			}

			return Ok();
		}
	}
}
