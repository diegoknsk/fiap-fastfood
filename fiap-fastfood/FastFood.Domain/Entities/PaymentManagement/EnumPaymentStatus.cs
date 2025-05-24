using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Entities.PaymentManagement
{
    public enum EnumPaymentStatus
    {
        NotStarted = 0,         // Nenhuma tentativa de pagamento
        Started = 1,            // Cliente iniciou o pagamento
        QrCodeGenerated = 2,    // QR Code emitido
        Approved = 3,           // Pagamento confirmado
        Rejected = 4,           // Pagamento recusado
        Canceled = 5            // Cliente cancelou / timeout / erro
    }
}
