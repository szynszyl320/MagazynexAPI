// Endpoint powitalny, zwracający "Hello World!"
app.MapGet("/", () => "Podaj Informacje do kazdego z pól");

// Endpoint do pobierania wszystkich elementów z bazy danych dla pracowników
app.MapGet("/todoitems", async (PracownikDb db) =>
    await db.Topra.ToListAsync());

// Endpoint do pobierania pojedynczego elementu po jego identyfikatorze dla pracowników
/*app.MapGet("/todoitems/{id}", async (int id, PracownikDb db) =>
{
    var todo = await db.Topra.FindAsync(id);
    return todo != null ? Results.Ok(todo) : Results.NotFound();
});*/

// Endpoint do dodawania nowego elementu dla pracowników
app.MapPost("/todoitems", async (Pracownik todo, PracownikDb db) =>
{
    db.Topra.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todoitems/{todo.Id}", todo);
});

// Endpoint do aktualizacji istniejącego elementu
app.MapPut("/todoitems/{id}", async (int id, Pracownik inputTodo, PracownikDb db) =>
{
    var todo = await db.Topra.FindAsync(id);
    if (todo == null) return Results.NotFound();

    todo.Imie = inputTodo.Imie;
    todo.Nazwisko = inputTodo.Nazwisko;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint do usuwania elementu
app.MapDelete("/todoitems/{id}", async (int id, PracownikDb db) =>
{
    var topra = await db.Topra.FindAsync(id);
    if (topra == null) return Results.NotFound();

    db.Topra.Remove(topra);
    await db.SaveChangesAsync();
    return Results.NoContent();
});















using Magazynex_console;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Magazynex_console
{
    public class Pracownik
    {
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Stanowisko { get; set; }
        public int Id { get; set; }
        public int Numer_Telefonu { get; set; }
        public Magazyn? Magazyn { get; set; }

        public bool Assign_Name(string name)
        { 
            if (name.Length < 2)
            {
                return false;
            }
            else
            {
                Imie = name;
                return true;
            }
            
        }

        public bool Assign_Surname(string Surname)
        {
            while (true)

                if (Surname.Length < 2)
                {
                    return false;
                }
                else
                {
                    Nazwisko = Surname;
                    return true;
                }
        }


        public void Assign_Position(string stanowisko)
        {
            Stanowisko = stanowisko;
        }

        public void Assing_Numer_telefonu(string numer_telefonu)
        {
            numer_telefonu.Replace(" ", "");
            Numer_Telefonu = Convert.ToInt32(numer_telefonu);
        }

    }
}
class PracownikDb : DbContext
{
    public PracownikDb(DbContextOptions<PracownikDb> options)
        : base(options) { }

    public DbSet<Pracownik> Topra => Set<Pracownik>();
}
