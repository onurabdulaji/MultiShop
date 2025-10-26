using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService 
        (IMongoCollection<Category> _categoryCollection , IMapper _mapper)
        : ICategoryService
    {
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);

            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(q => q.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(q => true).ToListAsync();

            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find(q => q.CategoryId == id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);

            await _categoryCollection.FindOneAndReplaceAsync(q => q.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
