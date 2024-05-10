using Magazynex_console;
using Microsoft.EntityFrameworkCore;
using Namotion.Reflection;
using NSwag.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FirmaDb>(opt => opt.UseInMemoryDatabase("Firmy"));
builder.Services.AddDbContext<MagazynDb>(opt => opt.UseInMemoryDatabase("Magazyny"));
builder.Services.AddDbContext<TowarDb>(opt => opt.UseInMemoryDatabase("Towary"));
builder.Services.AddDbContext<PracownikDb>(opt => opt.UseInMemoryDatabase("Pracownicy"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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


app.MapGet("/firmas", async (FirmaDb db) =>
{
    var firmaItems = await db.Firmas.ToListAsync();
    return Results.Ok(firmaItems);
});


app.MapGet("/firmas/{Nazwa}", async (string Nazwa, FirmaDb db) =>
{
    var firmaItem = await db.Firmas.FirstOrDefaultAsync(f => f.Nazwa == Nazwa);

    return firmaItem != null ? Results.Ok(firmaItem) : Results.NotFound();
});

app.MapPost("/firmas", async (Firma todo, FirmaDb db) =>
{
    db.Firmas.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/firmas/{todo.Nazwa}", todo);
});

app.MapPut("/firmas/{Nazwa}", async (string Nazwa, Firma inputTodo, FirmaDb db) =>
{
    var firmaItem = await db.Firmas.FirstOrDefaultAsync(f => f.Nazwa == Nazwa);

    if (firmaItem is null) return Results.NotFound();

    firmaItem.Nazwa = inputTodo.Nazwa;
    firmaItem.Numer_Telefonu = inputTodo.Numer_Telefonu;

    await db.SaveChangesAsync();

    return Results.NoContent();
});


app.MapDelete("/firmas/{Nazwa}", async (string Nazwa, FirmaDb db) =>
{
    var firmaItem = await db.Firmas.FirstOrDefaultAsync(f => f.Nazwa == Nazwa);

    if (firmaItem != null)
    {
        db.Firmas.Remove(firmaItem);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});


// Magazyn

app.MapGet("/magazyns", async (MagazynDb db) =>
{
    var magazynitems = await db.magazyns.ToListAsync();
    return Results.Ok(magazynitems);
});

app.MapGet("/magazyns{Nazwa}", async (string Nazwa, MagazynDb db) =>
{
    var magazynItem = await db.magazyns.FirstOrDefaultAsync(f => f.Nazwa == Nazwa);
    return magazynItem != null ? Results.Ok(magazynItem) : Results.NotFound();
});

app.MapPost("/magazyns", async (Magazyn todo, MagazynDb db) =>
{
    db.magazyns.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/magazyns/{todo.Nazwa}", todo);
});

app.MapPut("/magazyns/{Nazwa}", async (string Nazwa, Magazyn inputTodo, MagazynDb db) =>
{
    var magazynItem = await db.magazyns.FirstOrDefaultAsync(f => f.Nazwa == Nazwa);
    if (magazynItem is null) return Results.NotFound();
    magazynItem.Nazwa = inputTodo.Nazwa;
    magazynItem.lokalizacja = inputTodo.lokalizacja;
    magazynItem.Pracownicy = inputTodo.Pracownicy;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/magazyns/{Nazwa}", async (string Nazwa, MagazynDb db) =>
{
    var magazynItem = await db.magazyns.FirstOrDefaultAsync(f => f.Nazwa == Nazwa);
    if (magazynItem != null)
    {
        db.magazyns.Remove(magazynItem);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

// Towary

app.MapGet("/towars", async (TowarDb db) =>
{
    var towarItem = await db.Towars.ToListAsync();
    return Results.Ok(towarItem);
});

app.MapGet("/towars{Nazwa_Produktu}", async (string Nazwa_Produktu, TowarDb db) =>
{
    var towarItem = await db.Towars.FirstOrDefaultAsync(f => f.Nazwa_Produktu == Nazwa_Produktu);
    return towarItem != null ? Results.Ok(towarItem) : Results.NotFound();
});

app.MapPost("/towars", async (Towar towar, TowarDb db) =>
{
    db.Towars.Add(towar);
    await db.SaveChangesAsync();
    return Results.Created($"/towars/{towar.Nazwa_Produktu}", towar);
});

app.MapPut("/towars/{Nazwa_Produktu}", async (string Nazwa_Produktu, Towar inputTowar, TowarDb db) =>
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

app.MapDelete("/towars/{Nazwa_Produktu}", async (string Nazwa_Produktu, TowarDb db) =>
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
















app.Run();
