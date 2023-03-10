using Helper.Contrato;
using Helper.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//habilita la recepcion del XML & Jason 
builder.Services.AddMvc().AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters();

//AGREGO LA INYECCION DE DEPENDENCIA PARA LAS PETICONES HTTP
builder.Services.AddSingleton<IRestHelper, RestHelper>();

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
