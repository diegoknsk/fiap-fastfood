using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Domain.Entities.OrderManagement
{
    public enum EnumOrderStatus
    {
        Started = 0,                    // Cliente está montando o pedido
        AwaitingPayment = 1,           // Produtos escolhidos, aguardando pagamento
        PaymentConfirmed = 2,          // Pagamento aprovado
        OrderNumberGenerated = 3,      // Código gerado, pedido é oficial
        AwaitingKitchenPriority = 4,   // Aguardando a cozinha priorizar o pedido
        InPreparation = 5,             // Pedido sendo preparado
        ReadyForPickup = 6,            // Pronto para retirada
        Finished = 7,                 // Entregue ao cliente
        Canceled =8                   // Cancelado antes da entrega
    }
}
