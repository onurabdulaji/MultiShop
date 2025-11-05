using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler(IRepository<Address> _repository)
    {
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            return values.Select(q => new GetAddressQueryResult
            {
                AddressId = q.AddressId,
                City = q.City,
                Detail = q.Detail,
                District = q.District,
                UserId = q.UserId,
            }).ToList();
        }
    }
}
