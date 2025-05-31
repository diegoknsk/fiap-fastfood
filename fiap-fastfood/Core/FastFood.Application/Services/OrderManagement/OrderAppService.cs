using FastFood.Application.Models.OrderManagement;
using FastFood.Application.Models.OrderManagement.FastFood.Application.Models.OrderManagement;
using FastFood.Domain.Common.Exceptions;
using FastFood.Domain.Entities.OrderManagement;
using FastFood.Domain.Entities.PaymentManagement;
using FastFood.Domain.Ports.Common;
using FastFood.Domain.Ports.OrderManagement;

namespace FastFood.Application.Services.OrderManagement;

public class OrderAppService : IOrderAppService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IOrderedProductRepository _orderedProductRepository;


    public OrderAppService(IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IOrderedProductRepository orderedProductRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _orderedProductRepository = orderedProductRepository;
    }

    public async Task<Guid> StartOrderAsync(OrderCustomerStartModel customer)
    {
        await Task.CompletedTask;
        var order = new Order(
            id: null,
            code: null,
    null,
            paymentStatus: EnumPaymentStatus.NotStarted,
            orderStatus: EnumOrderStatus.Started,
            customerId: customer.CustomerId
        );

        var code = OrderCodeGenerator.Generate(customer.CustomerId);
        order.SetCode(code);

        await _orderRepository.AddAsync(order);
        await _unitOfWork.CommitAsync();

        return order.Id;
    }

    public async Task AddProductToOrderAsync(AddProductToOrderModel model)
    {
        var order = await _orderRepository.GetByIdAsync(model.OrderId, o => o.OrderedProducts);

        if (order is null)
            throw new ApplicationException("Pedido não encontrado.");

        if (order.OrderStatus != EnumOrderStatus.Started)
            throw new DomainException("Não é possível adicionar produtos após o fechamento do pedido.");

        var product = await _productRepository.GetByIdAsync(model.ProductId, p => p.Ingredients);

        if (product is null)
            throw new ApplicationException("Produto não encontrado.");

        var orderedProduct = new OrderedProduct(Guid.NewGuid(), product, model.Observation, model.Quantity);

        if (model.CustomIngredients is not null && model.CustomIngredients.Any())
        {
            foreach (var input in model.CustomIngredients)
            {
                
                orderedProduct.SetIngredientQuantity(input.IngredientId, input.Quantity);
            }
        }

        order.AddProduct(orderedProduct);

        await _orderedProductRepository.AddAsync(orderedProduct);
        await _unitOfWork.CommitAsync();
    }
    public async Task<OrderModel> GetOrderByIdAsync(Guid orderId)
    {
        var order = await _orderRepository.GetCompleteByIdAsync(orderId);

        if (order is null)
            throw new ApplicationException("Pedido não encontrado.");

        return new OrderModel
        {
            Id = order.Id,
            Code = order.Code,
            TotalPrice = order.TotalPrice,
            OrderStatus = order.OrderStatus,
            PaymentStatus = order.PaymentStatus,
            CreatedAt = order.CreatedAt,
            CustomerId = order.CustomerId,
            OrderedProducts = order.OrderedProducts.Select(p => new OrderedProductModel
            {
                Id = p.Id,
                ProductId = p.ProductId,
                ProductName = p.Product?.Name,
                Quantity = p.Quantity,
                FinalPrice = p.FinalPrice,
                Observation = p.Observation,
                Image = p.Product?.Image is not null
                    ? new ProductImageModel
                    {
                        Name = p.Product.Image.Name,
                        Url = p.Product.Image.Url
                    }
                    : null,
                CustomIngredients = p.CustomIngredients.Select(i => new CustomIngredientModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity,
                    ProductBaseIngredientId = i.ProductBaseIngredientId
                }).ToList()
            }).ToList()
        };
    }
    public async Task UpdateProductInOrderAsync(UpdateProductInOrderModel model)
    {
        var order = await _orderRepository.GetByIdWithProductsAndIngredientsAsync(model.OrderId);

        if (order is null)
            throw new ApplicationException("Pedido não encontrado.");

        if (order.OrderStatus != EnumOrderStatus.Started)
            throw new DomainException("Não é possível atualizar produtos após o fechamento do pedido.");

        var orderedProduct = order.OrderedProducts.FirstOrDefault(p => p.Id == model.OrderedProductId);

        if (orderedProduct is null)
            throw new ApplicationException("Produto não encontrado no pedido.");

        // Atualiza observação
        orderedProduct.SetObservation(model.Observation);

        // Atualiza quantidade
        orderedProduct.SetQuantity(model.Quantity);

        // Atualiza ingredientes customizados
        if (model.CustomIngredients is not null)
        {
            foreach (var input in model.CustomIngredients)
            {
                orderedProduct.SetIngredientQuantity(input.IngredientId, input.Quantity);
            }
        }

        await _orderRepository.UpdateAsync(order);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveProductFromOrderAsync(RemoveProductFromOrderModel model)
    {
        var order = await _orderRepository.GetByIdAsync(model.OrderId, o => o.OrderedProducts);

        if (order is null)
            throw new ApplicationException("Pedido não encontrado.");

        if (order.OrderStatus != EnumOrderStatus.Started)
            throw new DomainException("Não é possível remover produtos após o fechamento do pedido.");

        var productToRemove = order.OrderedProducts.FirstOrDefault(p => p.Id == model.OrderedProductId);

        if (productToRemove is null)
            throw new ApplicationException("Produto não encontrado no pedido.");

        order.OrderedProducts.Remove(productToRemove);

        await _orderRepository.UpdateAsync(order);
        await _unitOfWork.CommitAsync();
    }
}