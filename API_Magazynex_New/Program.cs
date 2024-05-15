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
    return Results.Ok(await firmaService.FirmaGetSpecific(Id));
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

app.MapGet("/magazyns", async (MagazynService service) =>
{
    return Results.Ok(await service.MagazynGetAll());
});

app.MapGet("/magazyns/{Id}", async (int Id, DatabaseContext db) =>
{
    var magazynItem = await db.magazyns.FirstOrDefaultAsync(f => f.Id == Id);

    return magazynItem != null ? Results.Ok(new MagazynSimpleDTO(magazynItem)) : Results.NotFound();
});

app.MapPost("/magazyns", async (MagazynCreateDTO dto, DatabaseContext db) =>
{
    Magazyn magazyn = new Magazyn();
    magazyn.Nazwa = dto.Nazwa;
    magazyn.lokalizacja = dto.lokalizacja;
    magazyn.Mozliwosc_Pechowywania_Materialow = dto.Mozliwosc_Pechowywania_Materialow;
    magazyn.Towary = new List<Towar>();
    magazyn.Pracownicy = new List<Pracownik>();
    
    db.magazyns.Add(magazyn);
    await db.SaveChangesAsync();
    return Results.Created($"/magazyns/{magazyn.Nazwa}", magazyn);
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

app.MapDelete("/magazyns/{Id}", async (int Id, DatabaseContext db) =>
{
    var magazynItem = await db.magazyns.FirstOrDefaultAsync(f => f.Id == Id);
    if (magazynItem != null)
    {
        db.magazyns.Remove(magazynItem);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

// Towary

app.MapGet("/towars", async (DatabaseContext db) =>
{
    var towarItem = await db.Towars.ToListAsync();
    return Results.Ok(towarItem);
});

app.MapGet("/towars/{Nazwa_Produktu}", async (string Nazwa_Produktu, DatabaseContext db) =>
{
    var towarItem = await db.Towars.FirstOrDefaultAsync(f => f.Nazwa_Produktu == Nazwa_Produktu);
    return towarItem != null ? Results.Ok(towarItem) : Results.NotFound();
});

app.MapPost("/towars", async (TowarCreateDTO dto, DatabaseContext db) =>
{
    Towar nowyTowar = new Towar();
    nowyTowar.Nazwa_Produktu = dto.Nazwa_Produktu;
    nowyTowar.Opis_Produktu = dto.Opis_Produktu;
    nowyTowar.Cena_Netto_Za_Sztuke = dto.Cena_Netto_Za_Sztuke;
    nowyTowar.Ilosc = dto.Ilosc;

    Firma? firma = db.Firmas.FirstOrDefault(x => x.Id == dto.Id_Firmy);
    Magazyn? magazyn = db.magazyns.FirstOrDefault(x => x.Id == dto.Id_Magazynu);
    
    nowyTowar.Firma = firma;
    nowyTowar.Magazyn = magazyn;
    nowyTowar.MagazynId = magazyn.Id;
    
    db.Towars.Add(nowyTowar);
    await db.SaveChangesAsync();
    return Results.Created($"/towars/{nowyTowar.Nazwa_Produktu}", new TowarySimpleDTO(nowyTowar));
});

app.MapPut("/towars/{Nazwa_Produktu}", async (string Nazwa_Produktu, Towar inputTowar, DatabaseContext db) =>
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

app.MapDelete("/towars/{Nazwa_Produktu}", async (string Nazwa_Produktu, DatabaseContext db) =>
{
    var towarItem = await db.Towars.FirstOrDefaultAsync(f => f.Nazwa_Produktu == Nazwa_Produktu);
    if (towarItem != null)
    {
        db.Towars.Remove(towarItem);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

// Pracownik

app.MapGet("/pracowniks", async (DatabaseContext db) =>
{
    var PracownikItem = await db.Pracowniks.ToListAsync();
    return Results.Ok(PracownikItem);
});

app.MapGet("/pracowniks/{Imie}", async (string Imie, DatabaseContext db) =>
{
    var pracownikItem = await db.Pracowniks.FirstOrDefaultAsync(f => f.Imie == Imie);
    return pracownikItem != null ? Results.Ok(pracownikItem) : Results.NotFound();
});

app.MapPost("/pracowniks/", async (Pracownik pracownik, DatabaseContext db) =>
{
    db.Pracowniks.Add(pracownik);
    await db.SaveChangesAsync();
    return Results.Created($"/pracowniks/{pracownik.Imie}", pracownik);
});

app.MapPut("/pracowniks/{Imie}", async (string Imie, Pracownik inputPracownik, DatabaseContext db) =>
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

app.MapDelete("/pracowniks/{Imie}", async (string Imie, DatabaseContext db) =>
{
    var pracownikItem = await db.Pracowniks.FirstOrDefaultAsync(f => f.Imie == Imie);
    if (pracownikItem != null)
    {
        db.Pracowniks.Remove(pracownikItem);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});










app.Run();
