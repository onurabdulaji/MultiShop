using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService(IMongoCollection<FeatureSlider> _featureSlider, IMapper _mapper) : IFeatureSliderService
    {
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);

            await _featureSlider.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSlider.DeleteOneAsync(q => q.FeatureSliderId == id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featureSlider.Find(q => true).ToListAsync();

            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var values = await _featureSlider.Find<FeatureSlider>(q => q.FeatureSliderId == id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdFeatureSliderDto>(values);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);

            await _featureSlider.FindOneAndReplaceAsync(q => q.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, values);
        }
    }
}
