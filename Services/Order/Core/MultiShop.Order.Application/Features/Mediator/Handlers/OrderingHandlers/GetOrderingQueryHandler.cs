using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler
        (IRepository<Ordering> repository)
        : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            return values.Select(q => new GetOrderingQueryResult
            {
                OrderingId = q.OrderingId,
                OrderDate = q.OrderDate,
                TotalPrice = q.TotalPrice,
                UserId = q.UserId,
            }).ToList();
        }
    }
}
