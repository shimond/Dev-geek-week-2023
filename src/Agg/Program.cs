var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/CallCatalog", async (HttpClient client) =>
{
    var respose = await client.GetAsync("http://firstWebApp/api/products");
    var data = await respose.Content.ReadAsStringAsync();
    return data;
})
.WithName("Test")
.WithOpenApi();

app.Run();

