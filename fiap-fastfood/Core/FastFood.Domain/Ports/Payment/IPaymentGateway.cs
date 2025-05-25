using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Ports.Payment
{
    public interface IPaymentGateway
    {
        Task<string> GenerateQrCodeAsync();
        Task<string> CheckPaymentStatusAsync();
    }
}
