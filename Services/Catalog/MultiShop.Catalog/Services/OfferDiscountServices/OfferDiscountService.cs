using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.OfferDiscountServices;

public class OfferDiscountService(IMongoCollection<OfferDiscount> _offerDiscountCollection, IMapper _mapper) : IOfferDiscountService
{
    public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
    {
        var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);

        await _offerDiscountCollection.InsertOneAsync(value);
    }

    public async Task DeleteOfferDiscountAsync(string id)
    {
        await _offerDiscountCollection.DeleteOneAsync(q => q.OfferDiscountId == id);
    }

    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
    {
        var values = await _offerDiscountCollection.Find(q => true).ToListAsync();

        return _mapper.Map<List<ResultOfferDiscountDto>>(values);
    }

    public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
    {
        var values = await _offerDiscountCollection.Find(q => q.OfferDiscountId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdOfferDiscountDto>(values);
    }

    public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        var values = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);

        await _offerDiscountCollection.FindOneAndReplaceAsync(q => q.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, values);
    }
}
