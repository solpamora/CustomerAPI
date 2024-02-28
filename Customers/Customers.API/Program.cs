using Customers.API;
using Customers.API.DataBaseContext;
using Customers.API.Interfaces.Repository;
using Customers.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



ConfigureServices(builder.Services);


// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

SeedDataBase(app);

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

void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IUsersRepository, UsersRepository>();
    services.AddDbContext<MyDataBaseContext>(options =>
        options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyDb"))        
    );   
}
void SeedDataBase (IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    var myDataBaseContext = services.GetRequiredService<MyDataBaseContext>();
    UserContextSeed.SeedAsync(myDataBaseContext);

}
