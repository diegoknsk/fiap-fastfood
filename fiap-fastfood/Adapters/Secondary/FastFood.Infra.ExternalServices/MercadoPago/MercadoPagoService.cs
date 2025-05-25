using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFood.Domain.Ports.Payment;

namespace FastFood.Infra.ExternalServices.MercadoPago
{
    public class MercadoPagoService : IPaymentGateway
    {
        public async Task<string> GenerateQrCodeAsync()
        {
            //todo retornar qr code inicialmente fake e depois plugar no serviço do mercado pago
            return await Task.FromResult("qrCode123456");
        }

        public async Task<string> CheckPaymentStatusAsync()
        {
            return await Task.FromResult("true");
        }
    }
}
