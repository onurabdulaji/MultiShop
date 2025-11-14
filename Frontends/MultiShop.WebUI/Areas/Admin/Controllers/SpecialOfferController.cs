using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/SpecialOffer")]
public class SpecialOfferController(IHttpClientFactory _httpClientFactory) : Controller
{
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ozel Teklifler";
        ViewBag.v3 = "Ozel Teklif ve Gunun Indirimi Lister";
        ViewBag.v0 = "Ozel Teklif Islemleri";

        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);

            return View(values);
        }
        return View();
    }

    [HttpGet]
    [Route("CreateSpecialOffer")]
    public IActionResult CreateSpecialOffer()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ozel Teklif";
        ViewBag.v3 = "Yeni Ozel Teklif Girisi";
        ViewBag.v0 = "Ozel Teklif Islemleri";

        return View();
    }

    [HttpPost]
    [Route("CreateSpecialOffer")]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        var client = _httpClientFactory.CreateClient();

        var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responeMessage = await client.PostAsync("https://localhost:7070/api/SpecialOffers", stringContent);

        if (responeMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
        return View();
    }

    [Route("DeleteSpecialOffer/{id}")]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.DeleteAsync("https://localhost:7070/api/SpecialOffers?id=" + id);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        return View();
    }

    [Route("UpdateSpecialOffer/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateSpecialOffer(string id)
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ozel Teklif";
        ViewBag.v3 = "Guncelleme Ozel Teklif Girisi";
        ViewBag.v0 = "Ozel Teklif Islemleri";

        var client = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers/" + id);

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);

            return View(values);
        }

        return View();
    }

    [Route("UpdateSpecialOffer/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        var client = _httpClientFactory.CreateClient();

        var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync("https://localhost:7070/api/SpecialOffers/", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        return View();
    }
}
