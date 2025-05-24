using FastFood.Domain.Common.Exceptions;

namespace FastFood.Domain.Entities.PaymentManagement
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public EnumPaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? QrCodeUrl { get; private set; }
        public string? ExternalTransactionId { get; private set; }

        protected Payment()
        {
        }

        public Payment(Guid orderId)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            Status = EnumPaymentStatus.NotStarted;
            CreatedAt = DateTime.UtcNow;
        }

        public void Start()
        {
            Status = EnumPaymentStatus.Started;
        }

        public void GenerateQrCode(string qrCodeUrl)
        {
            DomainValidation.ThrowIfNullOrWhiteSpace(qrCodeUrl, "QR Code is required.");

            QrCodeUrl = qrCodeUrl;
            Status = EnumPaymentStatus.QrCodeGenerated;
        }

        public void Approve(string transactionId)
        {
            DomainValidation.ThrowIfNullOrWhiteSpace(transactionId, "Transaction ID is required.");

            ExternalTransactionId = transactionId;
            Status = EnumPaymentStatus.Approved;
        }

        public void Reject()
        {
            Status = EnumPaymentStatus.Rejected;
        }

        public void Cancel()
        {
            Status = EnumPaymentStatus.Canceled;
        }
    }
}
