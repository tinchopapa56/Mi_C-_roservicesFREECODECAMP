using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Interfaces;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Settings;

var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;

//Mongo - DBs Injections
    builder.Services.Configure<ServiceSettings>(configuration.GetSection(nameof(ServiceSettings)));
    builder.Services.Configure<MongoDBSettings>(configuration.GetSection(nameof(MongoDBSettings)));

    builder.Services.AddSingleton(serviceProvider => 
    {
        var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
        var mongoDBSettings = configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
        var mongoClient = new MongoClient(mongoDBSettings.ConnectionString);
        return mongoClient.GetDatabase(serviceSettings.ServiceName);
    });

//D. Injection - Adds Singletons
    // builder.Services.AddSingleton<IItemRepository, ItemRepository>();
    builder.Services.AddSingleton<IRepository<Item>>(serviceProvider => 
    {
        var db = serviceProvider.GetService<IMongoDatabase>();
        return new MongoRepository<Item>(db, "items"); //items = collectionName
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
