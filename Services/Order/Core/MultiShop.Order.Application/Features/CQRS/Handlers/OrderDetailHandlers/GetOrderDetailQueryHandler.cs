using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
    {
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();

            return values.Select(q => new GetOrderDetailQueryResult
            {
                OrderDetailId = q.OrderDetailId,
                ProductAmount = q.ProductAmount,
                ProductName = q.ProductName,
                OrderingId = q.OrderingId,
                ProductId = q.ProductId,
                ProductPrice = q.ProductPrice,  
                ProductTotalPrice = q.ProductTotalPrice,
            }).ToList();
        }
    }
}
