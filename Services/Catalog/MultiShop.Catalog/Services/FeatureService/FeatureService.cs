using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.FeatureService;

public class FeatureService
     (IMongoCollection<Feature> _featureCollection, IMapper _mapper)
    : IFeatureService
{
    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        var value = _mapper.Map<Feature>(createFeatureDto);

        await _featureCollection.InsertOneAsync(value);
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _featureCollection.DeleteOneAsync(q => q.FeatureId == id);
    }

    public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
    {
        var values = await _featureCollection.Find(q => true).ToListAsync();

        return _mapper.Map<List<ResultFeatureDto>>(values);
    }

    public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
    {
        var values = await _featureCollection.Find(q => q.FeatureId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdFeatureDto>(values);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
        var values = _mapper.Map<Feature>(updateFeatureDto);

        await _featureCollection.FindOneAndReplaceAsync(q => q.FeatureId == updateFeatureDto.FeatureId, values);
    }
}
