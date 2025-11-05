using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController
        (
        GetAddressQueryHandler getAddressQueryHandler,
        GetAddressByIdQueryHandler getAddressByIdQueryHandler,
        CreateAddressCommandHandler createAddressCommandHandler,
        UpdateAddressCommandHandler updateAddressCommandHandler,
        RemoveAddressCommandHandler removeAddressCommandHandler
        )
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await getAddressQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var values = await getAddressByIdQueryHandler.Handler(new GetAddressByIdQuery(id));

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await createAddressCommandHandler.Handler(command);
            return Ok("Adres Bilgisi Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await updateAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi Guncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
           await removeAddressCommandHandler.Handler(new RemoveAddressCommand(id));
           return Ok("Adres Basariyla Silindi");
        }
    }
}
