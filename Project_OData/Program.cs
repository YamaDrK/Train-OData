using Project_OData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddWebAPIService();
builder.Services.AddInfrastructureService();

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
