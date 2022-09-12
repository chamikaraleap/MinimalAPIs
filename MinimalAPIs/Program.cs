using MinimalAPIs.Models;
using MinimalAPIs.Source;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndPointDefinitions(typeof(Customer));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title="title", Version=""}));

var app = builder.Build();


app.UseEndpointDefinitions();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Test API"));
}



app.UseHttpsRedirection();
//app.UseAuthorization();


app.Run();
