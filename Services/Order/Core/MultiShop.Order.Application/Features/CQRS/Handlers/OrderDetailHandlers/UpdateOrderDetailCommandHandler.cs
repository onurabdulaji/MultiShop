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
    public class UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        public async Task Handle (UpdateOrderDetailCommand command)
        {
            var values = await repository.GetByIdAsync(command.OrderDetailId);

            values.OrderDetailId = command.OrderDetailId;
            values.OrderingId = command.OrderingId;
            values.ProductId = command.ProductId;
            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProductTotalPrice = command.ProductTotalPrice;
            values.ProductAmount = command.ProductAmount;

            await repository.UpdateAsync(values);
        }
    }
}
