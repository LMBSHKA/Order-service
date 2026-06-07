namespace API.Contracts.Orders
{
	public class CreateOrderRequest
	{
		public decimal TotalAmount { get; set; }
		public string Currency { get; set; }

		public List<CreateOrderItemRequest> Items { get; set; } = new List<CreateOrderItemRequest>();
	}
}
