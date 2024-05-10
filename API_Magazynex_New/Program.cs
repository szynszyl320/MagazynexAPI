using Magazynex_console;
using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FirmaDb>(opt => opt.UseInMemoryDatabase("Firmy"));
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

app.Run();
