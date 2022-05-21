using Microsoft.EntityFrameworkCore;
using trackingApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//

builder.Services.AddDbContext<IssueDbContext>(
    o => o.UseSqlServer());

/*use the Services Property exposed by the builder object
invoke the method AddDbContext
you need to provide the type parameter which is the IssueDbContext
this way we are adding the data context to the service container
and a new instance of the DbContext will be created per request.
The AddDbContext method takes an action of DbContextOptions Builder, we can use this to configure the options on the DbContext
this is why we declare the DbContext Options in the constructor.
We use the method UseSqlServer to set the connectionstring of the database
now lets declare the connectionstring in the file appsettings.json
*/

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
