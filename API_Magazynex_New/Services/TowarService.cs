using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.CsvDTO;
using API_Magazynex_New.Encje;
using API_Magazynex_New.SimpleDTO;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace API_Magazynex_New.Services
{
    public class TowarService
    {
        private DatabaseContext _dbContext;

        public TowarService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TowarySimpleDTO>> TowaryGetAll()
        {
            var towaritems = await _dbContext.Towars.Include(x => x.Firma).Include(x => x.Magazyn).ToListAsync();
            
            return towaritems.Select(x => new TowarySimpleDTO(x)).ToList();
        }
        public async Task<TowarySimpleDTO> TowarGetSpecific(int Id)
        {
            return new TowarySimpleDTO(_dbContext.Towars.Include(x => x.Firma).Include(x => x.Magazyn).FirstOrDefault(x => x.id == Id));
        }

        public async Task<IResult> TowarExport()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            var TowarItems = await _dbContext.Towars.ToListAsync();
            var returnTowar = TowarItems.Select(x => new TowarCsvDTO(x)).ToList();

            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                csv.WriteRecords(returnTowar);
                writer.Flush();

                var content = memoryStream.ToArray();
                return Results.File(content, "text/csv", "towar.csv");
            }
        }

        public async Task<TowarySimpleDTO> CreateNewTowar(TowarCreateDTO dto)
        {
            Towar nowyTowar = new Towar();
            nowyTowar.Nazwa_Produktu = dto.Nazwa_Produktu;
            nowyTowar.Opis_Produktu = dto.Opis_Produktu;
            nowyTowar.Cena_Netto_Za_Sztuke = dto.Cena_Netto_Za_Sztuke;
            nowyTowar.Ilosc = dto.Ilosc;
            nowyTowar.Klasa_Towaru = dto.Klasa_Towaru;

            Firma? firma = _dbContext.Firmas.FirstOrDefault(x => x.Id == dto.Id_Firmy);
            Magazyn? magazyn = _dbContext.Magazyns.FirstOrDefault(x => x.Id == dto.Id_Magazynu);

            bool contains = magazyn.Przechowywane_Materialy.Contains(nowyTowar.Klasa_Towaru);
            if (!contains)
            { throw new ArgumentException("Magazyn nie jest w stanie przechowywac towarow tej klasy");  }

            nowyTowar.Firma = firma;
            nowyTowar.Magazyn = magazyn;
            nowyTowar.MagazynId = magazyn.Id;

            _dbContext.Towars.Add(nowyTowar);
            await _dbContext.SaveChangesAsync();

            return new TowarySimpleDTO(nowyTowar);
        }
        public async Task<bool> DeleteTowar(int Id)
        {
            var towarItem = await _dbContext.Towars.FirstOrDefaultAsync(f => f.id == Id);

            if (towarItem != null)
            {
                _dbContext.Towars.Remove(towarItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateTowar(int Id, TowarCreateDTO dto)
        {
            var towarItem = await _dbContext.Towars.FirstOrDefaultAsync(f => f.id == Id);
            if (towarItem == null) { return false; }
            
            towarItem.Nazwa_Produktu = dto.Nazwa_Produktu;
            towarItem.Opis_Produktu = dto.Opis_Produktu;
            towarItem.Ilosc = dto.Ilosc;
            towarItem.Cena_Netto_Za_Sztuke = dto.Cena_Netto_Za_Sztuke;
            towarItem.MagazynId = dto.Id_Magazynu;
            towarItem.FirmaId = dto.Id_Firmy;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
