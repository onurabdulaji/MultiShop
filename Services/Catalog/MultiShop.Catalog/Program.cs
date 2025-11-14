using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Mapping;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeatureService;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices;
using MultiShop.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "ResourceCatalog";

    options.RequireHttpsMetadata = false;

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("Authentication Failed: " + context.Exception.Message);
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine("Token Successfully Validated for User: " + context.Principal.Identity.Name);
            return Task.CompletedTask;
        }
    };
});



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

builder.Services.AddScoped<IMongoCollection<FeatureSlider>>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<FeatureSlider>(settings.FeatureSliderCollectionName);
});

builder.Services.AddScoped<IMongoCollection<SpecialOffer>>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<SpecialOffer>(settings.SpecialOfferCollectionName);
});

builder.Services.AddScoped<IMongoCollection<Feature>>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    var database = client.GetDatabase(settings.DatabaseName);
    return database.GetCollection<Feature>(settings.FeatureCollectionName);
});


// MONGO DB SETTINGS => LATER WE WILL ADD THESE TO EXTENSION METHODS

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();

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

//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
