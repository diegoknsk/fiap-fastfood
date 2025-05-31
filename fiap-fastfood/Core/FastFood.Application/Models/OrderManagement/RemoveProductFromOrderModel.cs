namespace FastFood.Application.Models.OrderManagement
{
    public class RemoveProductFromOrderModel
    {
        public Guid OrderId { get; set; }
        public Guid OrderedProductId { get; set; }
    }
}
