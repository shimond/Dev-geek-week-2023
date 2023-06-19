using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(x => x.UseInMemoryDatabase("CATALOG"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
// https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-7.0&tabs=windows
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddOutputCache();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();
var fromSe = app.Configuration["KeyFromSecret"];


app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.UseOutputCache();
app.UseAuthentication();
app.UseAuthorization();
app.AddProductsRoutes();

app.Run();







//app.MapControllers();



//var valueFromConfig = app.Configuration["test"];
