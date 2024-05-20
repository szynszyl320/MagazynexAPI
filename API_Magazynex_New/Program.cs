using API_Magazynex_New.SimpleDTO;
using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<MagazynService>();
builder.Services.AddScoped<FirmaService>();
builder.Services.AddScoped<PracownikService>();
builder.Services.AddScoped<TowarService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "MagazynexAPI";
    config.Title = "MagazynexAPI v1";
    config.Version = "v1";
});

builder.Services.AddCors(o => o.AddPolicy("Cors_Access", builder =>
{
    builder.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "MagazynexAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.UseCors("Cors_Access");

app.MapGet("/firmas", async (FirmaService firma) =>
{ 
    return Results.Ok(await firma.FirmaGetAll());
});


app.MapGet("/firmas/{Id}", async (int Id, FirmaService firmaService) =>
{
    var returnmagazyn = await firmaService.FirmaGetSpecific(Id);
    return returnmagazyn != null ? Results.Ok(returnmagazyn) : Results.NotFound();
});


app.MapPost("/firmas", async (FirmaService firmaService, FirmaCreateDTO dto) =>
{
    var firmareturn = await firmaService.CreateNewFirma(dto);
    return Results.Created($"/firmas/{firmareturn.Id}", firmareturn);
});

app.MapPut("/firmas/{Id}", async (FirmaService firmaService, int Id, FirmaCreateDTO dto) =>
{
    if (await firmaService.UpdateFirma(Id, dto))
    { return Results.NoContent(); }
    else
    { return Results.NotFound(); }
});
app.MapPut("/firmas/{Id}/restore", async (FirmaService firmaService, int Id, FirmaCreateDTO dto) =>
{
    if (await firmaService.ReactivateFirma(Id))
    { return Results.NoContent();  }
    else
    { return Results.NotFound(); }
});

app.MapDelete("/firmas/{Id}", async (FirmaService firmaService, int Id) =>
{
    if (await firmaService.DeleteFrima(Id))
    { return Results.NoContent(); }
    else
    { return Results.NotFound(); }
});


// Magazyn

app.MapGet("/magazyns", async (MagazynService magazynService) =>
{
    return Results.Ok(await magazynService.MagazynGetAll());
});

app.MapGet("/magazyns/{Id}", async (int Id, MagazynService magazynService) =>
{
    var returnmagazyn = await magazynService.MagazynGetSpecific(Id);
    return returnmagazyn != null ? Results.Ok(returnmagazyn) : Results.NotFound();
});

app.MapPost("/magazyns", async (MagazynCreateDTO dto, MagazynService magazynService) =>
{
    MagazynSimpleDTO returnmagazyn = await magazynService.CreateNewMagazyn(dto);
    return Results.Created($"/magazyns/{returnmagazyn.Nazwa}", returnmagazyn);
});

app.MapPut("/magazyns/{Id}", async (int Id, MagazynService magazynService, MagazynCreateDTO dto) =>
{
    if (await magazynService.UpdateMagazyn(Id, dto))
    { return Results.NoContent(); }
    else
    { return Results.NoContent(); }
});

app.MapPut("/magazyns/{Id}/restore", async (int Id, MagazynService magazynService) =>
{ 
    if (await magazynService.ReactivateMagazyn(Id))
    { return Results.NoContent(); }
    else
    { return Results.NotFound(); }
});

app.MapDelete("/magazyns/{Id}", async (int Id, MagazynService magazynService) =>
{
    if (await magazynService.DeleteMagazyn(Id))
    { return Results.NoContent(); }
    else
    {  return Results.NotFound(); }
});

// Towary

app.MapGet("/towars", async (TowarService towarService) =>
{
    return Results.Ok(await towarService.TowaryGetAll());
});

app.MapGet("/towars/{id}", async (int Id, TowarService towarService) =>
{
    var returntowar = await towarService.TowarGetSpecific(Id);
    return returntowar != null ? Results.Ok(returntowar) : Results.NotFound();
});

app.MapPost("/towars", async (TowarCreateDTO dto, TowarService towarService) =>
{
    var returntowar = await towarService.CreateNewTowar(dto);
    return Results.Created($"/towars/{returntowar.name}", returntowar);
});


app.MapPut("/towars/{id}", async (int Id, TowarService towarService, TowarCreateDTO dto) =>
{
    if (await towarService.UpdateTowar(Id, dto))
    { return Results.NoContent(); }
    else
    { return Results.NotFound(); }
});


app.MapDelete("/towars/{id}", async (int Id, TowarService towarService) =>
{
    if (await towarService.DeleteTowar(Id))
    { return Results.NoContent(); }
    else
    { return Results.NotFound(); }
   
});

// Pracownik

app.MapGet("/pracowniks", async (PracownikService pracownikService) =>
{
    return Results.Ok(await pracownikService.PracownikGetAll());
});

app.MapGet("/pracowniks/{Id}", async (int Id, PracownikService pracownikService) =>
{
    var returnpracownik = await pracownikService.PracownikGetSpecific(Id);
    return returnpracownik != null ? Results.Ok(returnpracownik) : Results.NotFound();
});

app.MapPost("/pracowniks", async (PracownikCreateDTO dto, PracownikService pracownikService) =>
{
    var returnpracownik = await pracownikService.CreateNewPracownik(dto);
    return Results.Created($"/towars/{returnpracownik.Imie}", returnpracownik);
});

app.MapPut("/pracowniks/{Id}", async (int Id, PracownikService pracownikService, PracownikCreateDTO dto) =>
{
    if (await pracownikService.UpdatePracownik(Id, dto))
    { return Results.NoContent(); }
    else
    { return Results.NotFound(); }
});

app.MapDelete("/pracowniks/{Id}", async (int Id, PracownikService pracownikService) =>
{
    if (await pracownikService.DeletePracownik(Id))
    { return Results.NoContent(); }
    else
    { return Results.NotFound(); }
});


app.Run();


