using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailsCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailsQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController
        (
        GetOrderDetailQueryHandler getOrderDetailQueryHandler,
        GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
        CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
        UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler,
        RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler
        )
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await getOrderDetailQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailById(int id)
        {
            var values = await getOrderDetailByIdQueryHandler.Handler(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await createOrderDetailCommandHandler.Handle(command);
            return Ok("Siparis Detayi Basariyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Siparis Detayi Basariyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await updateOrderDetailCommandHandler.Handle(command);
            return Ok("Siparis Detayi Basariyla Guncellendi");
        }
    }
}
