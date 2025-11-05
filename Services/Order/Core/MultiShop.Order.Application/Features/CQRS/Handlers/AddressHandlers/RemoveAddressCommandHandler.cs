using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler(IRepository<Address> _repository)
    {
        public async Task Handler(RemoveAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.DeleteAsync(value);
        }
    }
}
