using Assignment.DataBaseAccess;
using Assignment.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Assignment.Repositories;
using Assignment.Interfaces.IServices;
using Assignment.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//enabel cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();

                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register DBcontext
var ConnectionStrings = builder.Configuration.GetConnectionString("inventoryControlSystemDbConnection");
builder.Services.AddDbContext< InventoryManagementDbContext>(options=>options.UseSqlServer(ConnectionStrings));

//Dependency Injection
builder.Services.AddScoped<ICategoryRepository ,CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
