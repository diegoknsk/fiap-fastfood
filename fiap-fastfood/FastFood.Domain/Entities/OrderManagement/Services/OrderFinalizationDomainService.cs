
using FastFood.Domain.Entities.PaymentManagement;
using FastFood.Domain.Entities.PreparationManagement;


namespace FastFood.Domain.Entities.OrderManagement.Services
{
    public class OrderFinalizationDomainService
    {
        public bool CanFinalizeOrder(Order order, Preparation preparation, Payment payment)
        {
            return preparation.Status == EnumPreparationStatus.Finished
                   && payment.Status == EnumPaymentStatus.Approved
                   && order.OrderStatus != EnumOrderStatus.Finished;
        }
    }
}
