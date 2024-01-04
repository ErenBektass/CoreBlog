using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.







builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger Documentation Section
var info = new OpenApiInfo()
{
	Title = "BlogAPI Dökümantasyonu",
	Version = "v1",
	Description = "Kullanýcýlarýn bloglarý incelebildigi yorum yapabildigi proje",
	Contact = new OpenApiContact()
	{
		Name = "Eren",
		Email = "erenbektas95@hotmail.com",
	}

};

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", info);

	// Set the comments path for the Swagger JSON and UI.
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	c.IncludeXmlComments(xmlPath);
});

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
