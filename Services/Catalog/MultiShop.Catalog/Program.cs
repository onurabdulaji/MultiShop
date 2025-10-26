using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Mapping;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MONGO DB SETTINGS => LATER WE WILL ADD THESE TO EXTENSION METHODS

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddScoped<IMongoCollection<Category>>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<Category>(settings.CategoryCollectionName);
});

builder.Services.AddScoped<IMongoCollection<Product>>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<Product>(settings.ProductCollectionName);
});

builder.Services.AddScoped<IMongoCollection<ProductDetail>>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<ProductDetail>(settings.ProductDetailCollectionName);
});

builder.Services.AddScoped<IMongoCollection<ProductImage>>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<ProductImage>(settings.ProductImageCollectionName);
});

// MONGO DB SETTINGS => LATER WE WILL ADD THESE TO EXTENSION METHODS

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<GeneralMapping>();
    //config.AddMaps(typeof(GeneralMapping).Assembly);
    //config.AddMaps(Assembly.GetExecutingAssembly());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
