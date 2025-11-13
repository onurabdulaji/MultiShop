using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.SpecialOfferServices;

public class SpecialOfferService
     (IMongoCollection<SpecialOffer> _specialOfferCollection, IMapper _mapper)
    : ISpecialOfferService
{
    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);

        await _specialOfferCollection.InsertOneAsync(value);
    }

    public async Task DeleteSpecialOfferAsync(string id)
    {
        await _specialOfferCollection.DeleteOneAsync(q => q.SpecialOfferId == id);
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
    {
        var values = await _specialOfferCollection.Find(q => true).ToListAsync();

        return _mapper.Map<List<ResultSpecialOfferDto>>(values);
    }

    public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
    {
        var values = await _specialOfferCollection.Find(q => q.SpecialOfferId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdSpecialOfferDto>(values);
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        var values = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);

        await _specialOfferCollection.FindOneAndReplaceAsync(q => q.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, values);
    }
}
