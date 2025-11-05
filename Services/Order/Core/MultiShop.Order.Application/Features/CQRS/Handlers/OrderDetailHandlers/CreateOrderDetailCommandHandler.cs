using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailsCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        public async Task Handle (CreateOrderDetailCommand command)
        {
            await repository.CreateAsync(new OrderDetail
            {
                ProductAmount = command.ProductAmount,
                ProductName = command.ProductName,
                OrderingId = command.OrderingId,
                ProductId = command.ProductId,
                ProductPrice = command.ProductPrice,
                ProductTotalPrice = command.ProductTotalPrice,
            });
        }
    }
}
