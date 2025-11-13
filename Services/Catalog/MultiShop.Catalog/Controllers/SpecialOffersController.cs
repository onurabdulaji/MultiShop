using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers;

//[Authorize]
[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class SpecialOffersController(ISpecialOfferService _specialOfferService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SpecialOfferList()
    {
        var values = await _specialOfferService.GetAllSpecialOfferAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecialOfferById(string id)
    {
        var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);

        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);

        return Ok("Ozel Teklif Basariyla Eklendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);

        return Ok("Ozel Teklif Silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);

        return Ok("Ozel Teklif Guncellendi");
    }
}
