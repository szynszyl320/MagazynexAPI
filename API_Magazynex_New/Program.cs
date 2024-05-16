using API_Magazynex_New;
using API_Magazynex_New.Encje;
using API_Magazynex_New.SimpleDTO;
using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Namotion.Reflection;
using NSwag.AspNetCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using API_Magazynex_New.Services;

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
    var firmareturn = firmaService.CreateNewFirma(dto);
    return Results.Created($"/firmas/{firmareturn.Id}", firmareturn);
});

/*app.MapPut("/firmas/{Nazwa}", async (string Nazwa, Firma inputTodo, DatabaseContext db) =>
{
    var firmaItem = await db.Firmas.FirstOrDefaultAsync(f => f.Nazwa == Nazwa);

    if (firmaItem is null) return Results.NotFound();

    firmaItem.Nazwa = inputTodo.Nazwa;
    firmaItem.Numer_Telefonu = inputTodo.Numer_Telefonu;

    await db.SaveChangesAsync();

    return Results.NoContent();
});*/


app.MapDelete("/firmas/{Id}", async (FirmaService firmaService, int Id) =>
{
    if (await firmaService.DeleteFrima(Id))
    {
        return Results.NoContent();
    }
    else
    {
        return Results.NotFound();
    }
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

/*app.MapPut("/magazyns/{Nazwa}", async (string Nazwa, Magazyn inputTodo, DatabaseContext db) =>
{
    var magazynItem = await db.magazyns.FirstOrDefaultAsync(f => f.Nazwa == Nazwa);
    if (magazynItem is null) return Results.NotFound();
    magazynItem.Nazwa = inputTodo.Nazwa;
    magazynItem.lokalizacja = inputTodo.lokalizacja;
    magazynItem.Pracownicy = inputTodo.Pracownicy;
    await db.SaveChangesAsync();
    return Results.NoContent();
});*/

app.MapDelete("/magazyns/{Id}", async (int Id, MagazynService magazynService) =>
{
    if (await magazynService.DeleteMagazyn(Id))
    {
        return Results.NoContent();
    }
    else
    {
        return Results.NotFound();
    }
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

/*app.MapPut("/towars/{Nazwa_Produktu}", async (string Nazwa_Produktu, Towar inputTowar, DatabaseContext db) =>
{
    var towarItem = await db.Towars.FirstOrDefaultAsync(f => f.Nazwa_Produktu == Nazwa_Produktu);
    if (towarItem is null) return Results.NotFound();
    towarItem.Firma = inputTowar.Firma;
    towarItem.Magazyn = inputTowar.Magazyn;
    towarItem.Opis_Produktu = inputTowar.Opis_Produktu;
    towarItem.Klasa_Towarow_Niebezpiecznych = inputTowar.Klasa_Towarow_Niebezpiecznych;
    towarItem.Cena_Netto_Za_Sztuke = inputTowar.Cena_Netto_Za_Sztuke;
    towarItem.Ilosc = inputTowar.Ilosc;
    towarItem.Nazwa_Produktu = inputTowar.Nazwa_Produktu;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
*/
app.MapDelete("/towars/{id}", async (int Id, TowarService towarService) =>
{
    if (await towarService.DeleteTowar(Id))
    { 
        return Results.NoContent();
    }
    else
    { 
        return Results.NotFound(); 
    }
   
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

/*app.MapPut("/pracowniks/{Imie}", async (string Imie, Pracownik inputPracownik, DatabaseContext db) =>
{
    var pracownikItem = await db.Pracowniks.FirstOrDefaultAsync(f => f.Imie == Imie);
    if (pracownikItem is null) return Results.NotFound();
    pracownikItem.Imie = inputPracownik.Imie;
    pracownikItem.Nazwisko = inputPracownik.Nazwisko;
    pracownikItem.Stanowisko = inputPracownik.Stanowisko;
    pracownikItem.Numer_Telefonu = inputPracownik.Numer_Telefonu;
    pracownikItem.Magazyn = inputPracownik.Magazyn;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
*/

app.MapDelete("/pracownik/{Id}", async (int Id, PracownikService pracownikService) =>
{
    if (await pracownikService.DeletePracownik(Id))
    {
        return Results.NoContent();
    }
    else
    {
        return Results.NotFound();
    }
});










app.Run();
