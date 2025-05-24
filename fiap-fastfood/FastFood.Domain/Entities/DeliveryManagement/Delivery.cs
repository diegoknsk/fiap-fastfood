using FastFood.Domain.Common.Exceptions;

namespace FastFood.Domain.Entities.DeliveryManagement
{
    public class Delivery
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public EnumDeliveryStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RetrievedAt { get; private set; }
        public DateTime? FinalizedAt { get; private set; }

        protected Delivery() { }
        public Delivery(
            Guid id,
            Guid orderId,
            EnumDeliveryStatus status,
            DateTime createdAt,
            DateTime? retrievedAt = null,
            DateTime? finalizedAt = null)
        {
            Id = id;
            OrderId = orderId;
            Status = status;
            CreatedAt = createdAt;
            RetrievedAt = retrievedAt;
            FinalizedAt = finalizedAt;
        }
        public void AddDelivery(Guid orderId)
        {
            Id = Guid.NewGuid();
            DomainValidation.ThrowIf(orderId == Guid.Empty, "OrderId is required.");
            OrderId = orderId;
            CreatedAt = DateTime.UtcNow;
            Status = EnumDeliveryStatus.Ready;
        }

        public void MarkAsRetrieved()
        {
            Status = EnumDeliveryStatus.Retrieved;
            RetrievedAt = DateTime.UtcNow;
        }

        public void FinalizeDelivery()
        {
            Status = EnumDeliveryStatus.Finalized;
            FinalizedAt = DateTime.UtcNow;
        }
    }
}
